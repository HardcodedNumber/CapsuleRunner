using UnityEngine;

namespace Source.Runtime.Player
{
    public class PlayerController : MonoBehaviour
    {
        private const int MouseButton = 0;

        private Transform _transform;
        private bool _move;

        [SerializeField]
        private Rigidbody _rigidbody = null;

        [SerializeField]
        private float _force = 1000f;

        public bool AllowInput { get; internal set; }

        private void Awake()
        {
            _transform = transform;
            AllowInput = true;
        }

        private void Update()
        {
#if !UNTITY_EDITOR && (UNITY_ANDROID || UNITY_IOS)
        if (Input.touchCount > 0) {
            _move = AllowInput;
        }
#else
            _move = Input.GetMouseButton(MouseButton) && AllowInput;
#endif
        }

        private void FixedUpdate()
        {
            if (_move) {
                _rigidbody.AddForce(_transform.forward * _force * Time.fixedDeltaTime);
            }
        }
    }
}