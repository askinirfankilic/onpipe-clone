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
            //home and gameplay panels are interbbedded in the base game
            public GameObject homeGameplay;
            public GameObject fail;
            public GameObject success;
        }

        #region Public Fields

        public bool nonGameplayUIIsOpen = true;

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

            uIPanels.homeGameplay.SetActive( true );
        }

        private async void LoadFail()
        {
            nonGameplayUIIsOpen = true;
            uIPanels.homeGameplay.SetActive( false );

            //await ... seconds before fail panel active
            await Task.Delay( TimeSpan.FromSeconds( 0.5f ) );

            uIPanels.fail.SetActive( true );
        }

        private async void LoadSuccess()
        {
            
            uIPanels.homeGameplay.SetActive( false );

            //await ... seconds before success panel active
            await Task.Delay( TimeSpan.FromSeconds( 1.5f ) );

            uIPanels.success.SetActive( true );
            nonGameplayUIIsOpen = true;
        }

        

        private void OnEnable()
        {
            Managers.EventManager.OnPlayerDestroyed += LoadFail;
            Managers.EventManager.OnLevelFinished += LoadSuccess;
        }

        private void OnDisable()
        {
            Managers.EventManager.OnPlayerDestroyed -= LoadFail;
            Managers.EventManager.OnLevelFinished -= LoadSuccess;
        }


        #endregion
    }
}
