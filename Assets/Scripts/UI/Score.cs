using UnityEngine;
using TMPro;

namespace OnPipe.UI
{

    [DisallowMultipleComponent]
    public class Score : MonoBehaviour
    {
        #region Private Fields

        private TextMeshProUGUI scoreText;

        #endregion

        #region Unity Methods
        
        private void Awake()
        {
            scoreText = GetComponent<TextMeshProUGUI>();
        }

        #endregion

        #region Private Methods
        
        private void RefreshScore()
        {
            scoreText.text = "SCORE " + Managers.GameManager.Instance.Score.ToString();
        }

        #endregion

        private void OnEnable()
        {
            Managers.EventManager.OnGameStarted += RefreshScore;
            Managers.EventManager.OnCornDetection += RefreshScore;
        }

        private void OnDisable()
        {
            Managers.EventManager.OnCornDetection -= RefreshScore;
            Managers.EventManager.OnGameStarted -= RefreshScore;
        }
    }
}
