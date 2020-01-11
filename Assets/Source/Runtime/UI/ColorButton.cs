using UnityEngine;
using UnityEngine.UI;

namespace Source.Runtime.UI
{
    [ExecuteInEditMode]
    public class ColorButton : MonoBehaviour
    {
        public delegate void ColorButtonHandler(Color color);
        public event ColorButtonHandler ColorPressed;

        [SerializeField]
        private Color _color = Color.white;

        [SerializeField]
        private Button _button = null;

        private void Awake()
        {
            _button.onClick.AddListener(OnButtonClicked);
            SetColor();
        }

#if UNITY_EDITOR
        private void Update()
        {
            SetColor();
        }
#endif

        private void SetColor()
        {
            if (_button != null) {
                var colors = _button.colors;
                colors.normalColor = _color;
                colors.pressedColor = _color;
                colors.selectedColor = _color;

                _button.colors = colors;
            }
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(OnButtonClicked);
        }

        private void OnButtonClicked()
        {
            ColorPressed?.Invoke(_color);
        }
    }
}