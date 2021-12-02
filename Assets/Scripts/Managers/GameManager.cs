using UnityEngine;
using UnityEngine.SceneManagement;

namespace OnPipe.Managers
{

    [DisallowMultipleComponent]
    public class GameManager : MonoSingleton<GameManager>
    {
        #region Private Fields

        private bool isGameStarted = false;
        private int score;
        private int level;
        #endregion

        #region Properties

        public bool IsGameStarted { get => isGameStarted; set => isGameStarted = value; }
        public int Score { get => score; set => score = value; }
        public int Level { get => level; set => level = value; }

        #endregion

        #region Unity Methods
        private void Awake()
        {
            GetPreviousScore();
            GetPreviousLevel();

            EventManager.Invoke_OnGameStarted();

            DontDestroyOnLoad( gameObject );
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Reload prototype scene.
        /// </summary>
        public void RestartGame()
        {
            SceneManager.LoadScene( sceneBuildIndex: 0 );
        }

        #endregion

        #region Private Methods

        private void GetPreviousScore()
        {
            if ( !PlayerPrefs.HasKey( "score" ) )
            {
                score = 0;
                PlayerPrefs.SetInt( "score", score );
            }
            else
            {
                score = PlayerPrefs.GetInt( "score" );
            }
        }

        private void GetPreviousLevel()
        {
            if ( !PlayerPrefs.HasKey( "level" ) )
            {
                level = 1;
                PlayerPrefs.SetInt( "level", level );
            }
            else
            {
                level = PlayerPrefs.GetInt( "level" );
            }
        }

        private void SaveScore()
        {
            PlayerPrefs.SetInt( "score", score );
        }

        private void SaveLevel()
        {
            PlayerPrefs.SetInt( "level", level );
        }

        private void IncreaseScore()
        {
            score++;
        }

        #endregion

        private void OnEnable()
        {
            EventManager.OnCornDetection += IncreaseScore;
        }
        private void OnDestroy()
        {
            SaveLevel();
            SaveScore();
            EventManager.OnCornDetection -= IncreaseScore;
        }

    }
}
