using UnityEngine;

namespace Source.Runtime.CheckPoints
{
    public class CheckpointSystem : MonoBehaviour
    {
        public delegate void GoalReachedHandler();
        public event GoalReachedHandler GoalReached;

        private Checkpoint _currentCheckpoint;

        [SerializeField]
        private Checkpoint[] _checkponts = null;

        [SerializeField]
        private Checkpoint _goal = null;

        public Checkpoint CurrentCheckpoint => _currentCheckpoint;
        public Vector3 GoalPosition => _goal.transform.position;

        private void Awake()
        {
            ResetCheckpoints();

            for (int i = 0; i < _checkponts.Length; ++i) {
                _checkponts[i].CheckpointEntered += OnCheckpoinEntered;
            }

            _goal.CheckpointEntered += OnGoalEntered;
        }

        public void ResetCheckpoints()
        {
            _currentCheckpoint = _checkponts[0];
        }

        private void OnCheckpoinEntered(Checkpoint checkpoint)
        {
            _currentCheckpoint = checkpoint;
        }

        private void OnGoalEntered(Checkpoint checkpoint)
        {
            GoalReached?.Invoke();
        }
    }
}