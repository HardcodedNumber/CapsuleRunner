using Source.Runtime.Utils;
using UnityEngine;

namespace Source.Runtime.Obstacles
{
    /// <summary>
    /// Let the body flop around
    /// </summary>
    public class Obstacle : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            var gameObject = collision.gameObject;

            if (gameObject.tag == Tags.Player) {
                var rigidBody = gameObject.GetComponent<Rigidbody>();

                rigidBody.constraints = RigidbodyConstraints.None;
            }
        }
    }
}