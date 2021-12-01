using UnityEngine;

namespace OnPipe.UI
{

    [DisallowMultipleComponent]
    public class UIManager : MonoBehaviour
    {
        [System.Serializable]
        public class UIPanels
        {
            public GameObject home;
            public GameObject gameplay;
            public GameObject fail;
            public GameObject success;
        }

        #region Serialized Fields

        [SerializeField] UIPanels uIPanels;

        #endregion

        #region Unity Methods

        private void Awake()
        {
            if ( uIPanels == null )
            {
                Debug.LogError( "Null reference" );
                return;
            }

            uIPanels.gameplay.SetActive( true );
        }

        #endregion
    }
}
