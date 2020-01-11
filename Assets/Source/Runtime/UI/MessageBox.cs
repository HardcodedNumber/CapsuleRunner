using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Runtime.UI
{
    public class MessageBox : MonoBehaviour
    {
        private Action _okAction;
        private Action _cancelAction;

        [SerializeField]
        private GameObject _panel = null;

        [SerializeField]
        private TMP_Text _title = null;

        [SerializeField]
        private TMP_Text _message = null;

        [SerializeField]
        private Button _ok = null;

        [SerializeField]
        private Button _cancel = null;

        [SerializeField]
        private TMP_Text _okText = null;

        [SerializeField]
        private TMP_Text _cancelText = null;

        public bool Visible => _panel.activeInHierarchy;

        private void Awake()
        {
            _ok.onClick.AddListener(OnOkButton);
            _cancel.onClick.AddListener(OnCancelButton);
        }

        private void OnDestroy()
        {
            _ok.onClick.RemoveListener(OnOkButton);
            _cancel.onClick.RemoveListener(OnCancelButton);
        }

        public void Show(string title, string message, string okText, string cancelText, Action okCallback, Action cancelCallback)
        {
            _panel.SetActive(true);
            _title.text = title;
            _message.text = message;
            _okAction = okCallback;
            _cancelAction = cancelCallback;
            _okText.text = okText;
            _cancelText.text = cancelText;
        }

        private void Close()
        {
            _panel.SetActive(false);
        }

        private void OnOkButton()
        {
            _okAction?.Invoke();
            Close();
        }

        private void OnCancelButton()
        {
            _cancelAction?.Invoke();
            Close();
        }
    }
}