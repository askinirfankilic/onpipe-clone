using UnityEngine;
using UnityEngine.UI;

namespace OnPipe.UI
{
    [RequireComponent( typeof( Button ) ), DisallowMultipleComponent]
    public class StartButton : MonoBehaviour
    {
        private Button startButton;

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
    }
}
