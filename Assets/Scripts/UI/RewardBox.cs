using UnityEngine;
using UnityEngine.UI;

namespace OnPipe.UI
{

    [DisallowMultipleComponent]
    public class RewardBox : MonoBehaviour
    {
        #region Private Fields

        private float totalCornCount;
        private Image rewardBoxRadial;

        #endregion

        #region Unity Methods

        private void Awake()
        {
            rewardBoxRadial = GetComponent<Image>();

        }



        #endregion

        #region Private Fields
        
        private void RefreshRadial()
        {
            rewardBoxRadial.fillAmount += 1f / totalCornCount;
        }

        private void GetTotalCornCount( int totalCornCount )
        {
            this.totalCornCount = (float)totalCornCount;
        }

        #endregion

        private void OnEnable()
        {
            Managers.EventManager.OnCornCalculation += GetTotalCornCount;
            Managers.EventManager.OnCornDetection += RefreshRadial;
        }

        private void OnDisable()
        {
            Managers.EventManager.OnCornCalculation -= GetTotalCornCount;
            Managers.EventManager.OnCornDetection -= RefreshRadial;
        }
    }
}
