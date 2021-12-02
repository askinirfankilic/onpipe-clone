using UnityEngine;

namespace OnPipe.UI
{
    public class Gameplay : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField] private Animation rewardBoxAnimation;
        [SerializeField] private Animation levelScoreAnimation;
        
        #endregion

        #region Unity Methods

        private void OnEnable()
        {
            rewardBoxAnimation.Play();
            levelScoreAnimation.Play();
        }

        #endregion
    }
}
