using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnPipe.Player
{
    [DisallowMultipleComponent, RequireComponent( typeof( PlayerMovementController ), typeof( PlayerInput ) )]
    public class PlayerBehavior : MonoBehaviour
    {
        #region Public Fields

        #endregion

        #region Serialized Fields

        #endregion

        #region Private Fields

        private PlayerMovementController playerMovement;

        #endregion

        #region Properties

        #endregion

        #region Unity Methods

        private void Awake()
        {
            playerMovement = GetComponent<PlayerMovementController>();
        }

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        private void OnPlayerInputDown()
        {
            Debug.Log( "Down" );
        }

        private void OnPlayerInputStay()
        {
            Debug.Log( "Move" );
            
        }

        private void OnPlayerInputUp()
        {
            Debug.Log( "Up" );
        }

        #endregion



        private void OnEnable()
        {
            Managers.EventManager.OnMouseInputDown += OnPlayerInputDown;
            Managers.EventManager.OnMouseInputStay += OnPlayerInputStay;
            Managers.EventManager.OnMouseInputUp += OnPlayerInputUp;
        }

        private void OnDisable()
        {
            Managers.EventManager.OnMouseInputDown -= OnPlayerInputDown;
            Managers.EventManager.OnMouseInputStay -= OnPlayerInputStay;
            Managers.EventManager.OnMouseInputUp -= OnPlayerInputUp;
        }
    }
}
