using UnityEngine;
using TMPro;

namespace OnPipe.UI
{

    [DisallowMultipleComponent]
    public class Score : MonoBehaviour
    {
        private TextMeshProUGUI scoreText;

        private void Awake()
        {
            scoreText = GetComponent<TextMeshProUGUI>();
        }
        private void RefreshScore()
        {
            scoreText.text = "SCORE " + Managers.GameManager.Instance.Score.ToString();
        }

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
