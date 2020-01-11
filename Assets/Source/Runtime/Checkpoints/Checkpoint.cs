using Source.Runtime.Utils;
using UnityEngine;

namespace Source.Runtime.CheckPoints
{
    public class Checkpoint : MonoBehaviour
    {
        public delegate void CheckPointHandler(Checkpoint checkpoint);
        public event CheckPointHandler CheckpointEntered;

        private void OnTriggerEnter(Collider other)
        {
            var gameObject = other.gameObject;

            if (gameObject.tag == Tags.Player) {
                CheckpointEntered?.Invoke(this);
            }
        }
    }
}