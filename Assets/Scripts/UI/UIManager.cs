using UnityEngine;
using System.Threading.Tasks;
using System;

namespace OnPipe.UI
{

    [DisallowMultipleComponent]
    public class UIManager : Managers.MonoSingleton<UIManager>
    {
        [System.Serializable]
        public class UIPanels
        {
            public GameObject home;
            public GameObject gameplay;
            public GameObject fail;
            public GameObject success;
        }

        #region Public Fields

        public bool nonGameplayUIIsOpen = false;

        #endregion

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

        private async void LoadFail()
        {
            nonGameplayUIIsOpen = true;
            uIPanels.gameplay.SetActive( false );

            //await 0.5 second before fail panel active
            await Task.Delay( TimeSpan.FromSeconds( 1 ) );

            uIPanels.fail.SetActive( true );
        }

        private void LoadSuccess()
        {

        }

        private void LoadGameplay()
        {

        }

        private void OnEnable()
        {
            Managers.EventManager.OnPlayerDestroyed += LoadFail;
        }

        private void OnDisable()
        {
            Managers.EventManager.OnPlayerDestroyed -= LoadFail;

        }


        #endregion
    }
}
