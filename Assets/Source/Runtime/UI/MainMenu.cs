using Source.Runtime.Player;
using Source.Runtime.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Source.Runtime.UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField]
        private Button _playGame = null;

        [SerializeField]
        private Button _playerColorButton = null;

        [SerializeField]
        private GameObject _colorSwatches = null;

        [SerializeField]
        private ColorButton[] _colors = null;

        private void Awake()
        {
            _playGame.onClick.AddListener(OnPlayGameButton);
            _playerColorButton.onClick.AddListener(OnPlayerColorbutton);

            for (int i = 0; i < _colors.Length; ++i) {
                var color = _colors[i];

                color.ColorPressed += OnColorPressed;
            }
        }


        private void OnDestroy()
        {
            _playGame.onClick.RemoveListener(OnPlayGameButton);
            _playerColorButton.onClick.RemoveListener(OnPlayerColorbutton);

            for (int i = 0; i < _colors.Length; ++i) {
                var color = _colors[i];

                color.ColorPressed -= OnColorPressed;
            }
        }

        private void OnPlayGameButton()
        {
            SceneManager.LoadScene(SceneNames.MainScene);
        }

        private void OnPlayerColorbutton()
        {
            _colorSwatches.SetActive(!_colorSwatches.activeInHierarchy);
        }

        private void OnColorPressed(Color color)
        {
            //Must have the # so it will parse correctly in PlayerColor
            var hex = $"#{ColorUtility.ToHtmlStringRGBA(color)}";

            PlayerPrefs.SetString(PlayerColor.PlayerColorPref, hex);
            PlayerPrefs.Save();

            _colorSwatches.SetActive(false);
        }
    }
}