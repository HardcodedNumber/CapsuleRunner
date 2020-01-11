using UnityEngine;

namespace Source.Runtime.Camera
{
    [ExecuteInEditMode]
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField]
        private Transform _target = null;

        [SerializeField]
        private Vector3 _offset = new Vector3(1f, 10, 2f);

        [SerializeField]
        private Vector3 _lookOffset = Vector3.forward;

        // Update is called once per frame
        void Update()
        {
            if (_target != null) {
                transform.localPosition = _target.position + _offset;
                transform.LookAt(_target.position + _lookOffset);
            }
        }
    }
}