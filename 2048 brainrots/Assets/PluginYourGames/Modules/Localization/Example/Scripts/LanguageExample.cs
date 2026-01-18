using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace YG.Example
{
    public class LanguageExample : MonoBehaviour
    {
        public string ru, en, tr;

        [SerializeField] private TextMeshProUGUI textComponent;

        private void Start()
        {
            textComponent = GetComponent<TextMeshProUGUI>();
            //SwitchLanguage(YG2.lang);
        }

        private void OnEnable()
        {
            //SwitchLanguage(YG2.lang);
        }

        private void OnDisable()
        {
            //SwitchLanguage(YG2.lang);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Keypad0))
            {
                SwitchLanguage("ru");
            }
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                SwitchLanguage("en");
            }
        }

        public void SwitchLanguage(string lang)
        {
            switch (lang)
            {
                case "ru":
                    textComponent.text = ru;
                    break;
                case "tr":
                    textComponent.text = tr;
                    break;
                default:
                    textComponent.text = en;
                    break;
            }
        }
    }
}