using Source.Runtime.Utils;
using UnityEngine;

namespace Source.Runtime.Trigger
{
    public class FailTrigger : MonoBehaviour
    {
        public delegate void PlayerFailedHandler();
        public event PlayerFailedHandler PlayerFailed;

        private void OnTriggerEnter(Collider other)
        {
            var gameObject = other.gameObject;

            if (gameObject.tag == Tags.Player) {
                PlayerFailed?.Invoke();
            }
        }
    }
}