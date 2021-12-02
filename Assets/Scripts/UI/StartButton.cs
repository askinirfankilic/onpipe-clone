using UnityEngine;
using UnityEngine.UI;

namespace OnPipe.UI
{
    [RequireComponent( typeof( Button ) ), DisallowMultipleComponent]
    public class StartButton : MonoBehaviour
    {
        #region Private Fields

        private Button startButton;

        #endregion

        #region Unity Methods
        
        private void Awake()
        {
            startButton = GetComponent<Button>();
            startButton.onClick.AddListener( () =>
            {
                UIManager.Instance.nonGameplayUIIsOpen = false;
                Managers.EventManager.Invoke_OnLevelStarted();
                gameObject.SetActive( false );
            } );
        }

        #endregion
    }
}
