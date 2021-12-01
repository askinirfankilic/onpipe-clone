using UnityEngine;
using UnityEngine.UI;

namespace OnPipe.UI
{

    [DisallowMultipleComponent]
    public class RewardBox : MonoBehaviour
    {
        private float totalCornCount;
        private Image rewardBoxRadial;
        private void Awake()
        {
            rewardBoxRadial = GetComponent<Image>();

        }

        private void RefreshRadial()
        {
            rewardBoxRadial.fillAmount += 1f / totalCornCount;
        }

        private void GetTotalCornCount( int totalCornCount )
        {
            this.totalCornCount = (float)totalCornCount;
        }

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
