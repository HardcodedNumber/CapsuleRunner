using UnityEngine;

namespace Source.Runtime.Player
{
    public class PlayerColor : MonoBehaviour
    {
        public const string PlayerColorPref = "PlayerColor";
        private const string DefaultPlayerColor = "FF0000FF";

        private MaterialPropertyBlock _propertyBlock;

        [SerializeField]
        private Renderer _renderer = null;

        private void Awake()
        {
            _propertyBlock = new MaterialPropertyBlock();
            _renderer.GetPropertyBlock(_propertyBlock);

            var hex = PlayerPrefs.GetString(PlayerColorPref, DefaultPlayerColor);

            if (!ColorUtility.TryParseHtmlString(hex, out Color color)) {
                Debug.LogError($"Unable to parse Hex: {hex}");
            }

            _propertyBlock.SetColor("_BaseColor", color);
            _renderer.SetPropertyBlock(_propertyBlock);
        }
    }
}