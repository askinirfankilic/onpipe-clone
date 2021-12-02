using UnityEngine;
using UnityEngine.UI;

namespace OnPipe
{
    [RequireComponent( typeof( Button ) ), DisallowMultipleComponent]
    public class RestartButton : MonoBehaviour
    {
        #region Private Fields
        
        private Button restartButton;

        #endregion

        #region Unity Methods
        
        private void Awake()
        {
            restartButton = GetComponent<Button>();
            restartButton.onClick.AddListener( Managers.GameManager.Instance.RestartGame );
        }

        #endregion

    }
}
