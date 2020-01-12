using Source.Runtime.CheckPoints;
using Source.Runtime.Player;
using Source.Runtime.Trigger;
using Source.Runtime.UI;
using Source.Runtime.Utils;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Source.Runtime.Gameplay
{
    public class GameplayService : MonoBehaviour
    {
        private const string QuitGameTitle = "Quit?";
        private const string RetryText = "Retry";
        private const string ReturnToMenu = "Main Menu";
        private const string GoalReachedTitle = "You won!";

        private float _playerTimer;
        private float _startDistance;

        [SerializeField]
        private MessageBox _messageBox = null;

        [SerializeField]
        private FailTrigger _failTrigger = null;

        [SerializeField]
        private CheckpointSystem _checkpointSystem = null;

        [SerializeField]
        private PlayerController _playerController = null;

        [SerializeField]
        private Rigidbody _player = null;

        [SerializeField]
        private Button _quitButton = null;

        [SerializeField]
        private TMP_Text _timeValue = null;

        [SerializeField]
        private Slider _progression = null;

        [SerializeField]
        private TMP_Text _tapToContinueText = null;

        private void Awake()
        {
            _playerTimer = 0f;
            _startDistance = Vector3.Distance(_player.position, _checkpointSystem.GoalPosition);

            _failTrigger.PlayerFailed += OnPlayerFailed;
            _quitButton.onClick.AddListener(OnQuitGame);

            _checkpointSystem.GoalReached += OnGoalReached;
            _playerController.PlayerMoved += OnPlayerMoved;
        }

        private void Update()
        {
            if (!_messageBox.Visible) {
                _playerTimer += Time.deltaTime;
                _timeValue.text = GetTime();
            }

            var playerDistance = Vector3.Distance(_player.position, _checkpointSystem.GoalPosition);

            _progression.value = 1 - (playerDistance / _startDistance);
        }

        private void OnDestroy()
        {
            _quitButton.onClick.RemoveListener(OnQuitGame);
            _checkpointSystem.GoalReached -= OnGoalReached;
            _playerController.PlayerMoved -= OnPlayerMoved;
            _failTrigger.PlayerFailed -= OnPlayerFailed;
        }

        private void MovePlayer(Vector3 position)
        {
            position.x = 0; //always make sure the player is center on the track;
            _player.MovePosition(position);
        }

        private string GetTime()
        {
            var timespan = TimeSpan.FromSeconds(_playerTimer);
            return timespan.ToString(@"mm\:ss");
        }

        private void OnQuitGame()
        {
            _messageBox.Show(QuitGameTitle, string.Empty, RetryText, ReturnToMenu, OnRetryGame, OnMainMenu);
        }

        private void OnPlayerFailed()
        {
            var current = _checkpointSystem.CurrentCheckpoint;
            MovePlayer(current.transform.position);
        }

        private void OnRetryGame()
        {
            _playerTimer = 0f;
            _checkpointSystem.ResetCheckpoints();
            _playerController.AllowInput = true;
            
            var current = _checkpointSystem.CurrentCheckpoint;

            MovePlayer(current.transform.position);
        }

        private void OnMainMenu()
        {
            SceneManager.LoadScene(SceneNames.MainMenu);
        }

        private void OnGoalReached()
        {
            var message = $"You took {GetTime()} to complete this level.";

            _messageBox.Show(GoalReachedTitle, message, RetryText, ReturnToMenu, OnRetryGame, OnMainMenu);
            _playerController.AllowInput = false;
        }

        private void OnPlayerMoved()
        {
            if (_tapToContinueText.gameObject.activeInHierarchy) {
                _tapToContinueText.gameObject.SetActive(false);
            }
        }
    }
}