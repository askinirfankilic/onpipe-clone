using UnityEngine;
using TMPro;

namespace OnPipe.UI
{

    [DisallowMultipleComponent]
    public class Level : MonoBehaviour
    {
        private TextMeshProUGUI levelText;

        private void Awake()
        {
            levelText = GetComponent<TextMeshProUGUI>();
        }

        private void AssignLevelText()
        {
            levelText.text = "LEVEL " + Managers.GameManager.Instance.Level.ToString();
        }

        private void OnEnable()
        {
            Managers.EventManager.OnGameStarted += AssignLevelText;
            
            //for non gameplay level texts
            AssignLevelText();
        }

        private void OnDisable()
        {
            Managers.EventManager.OnGameStarted -= AssignLevelText;
        }

    }
}
