using UnityEngine;
using UnityEngine.UI;

namespace OnPipe
{
    [RequireComponent( typeof( Button ) ), DisallowMultipleComponent]
    public class RestartButton : MonoBehaviour
    {
        private Button restartButton;

        private void Awake()
        {
            restartButton = GetComponent<Button>();
            restartButton.onClick.AddListener( Managers.GameManager.Instance.RestartGame );
        }

    }
}
