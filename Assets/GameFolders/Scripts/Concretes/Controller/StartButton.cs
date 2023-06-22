using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace UdemyProject3.UI
{
    public class StartButton : MonoBehaviour
    {
        Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(HandleOnButtonClicked);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(HandleOnButtonClicked);
        }

        void HandleOnButtonClicked()
        {
            GameManager.Instance.LoadScene("demo_map");
        }
    }

}
