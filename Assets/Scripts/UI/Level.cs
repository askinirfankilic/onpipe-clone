using UnityEngine;
using TMPro;

namespace OnPipe.UI
{

    [DisallowMultipleComponent]
    public class Level : MonoBehaviour
    {
        #region Private Fields

        private TextMeshProUGUI levelText;

        #endregion

        #region Unity Methods

        private void Awake()
        {
            levelText = GetComponent<TextMeshProUGUI>();
        }

        #endregion
        
        #region Private Methods
        
        private void AssignLevelText()
        {
            levelText.text = "LEVEL " + Managers.GameManager.Instance.Level.ToString();
        }

        #endregion

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
