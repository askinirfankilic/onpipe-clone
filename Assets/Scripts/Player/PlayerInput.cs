using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OnPipe.Managers;

namespace OnPipe.Player
{
    /// <summary>
    /// Handles all input for gameplay.
    /// </summary>
    [DisallowMultipleComponent]
    public class PlayerInput : MonoSingleton<PlayerInput>
    {
        #region Public Fields
        [Header( "SCREEN POSITIONS" )]
        public Vector2 onMouseDownCoordinates;
        public Vector2 onMouseStayCoordinates;
        public Vector2 onMouseUpCoordinates;

        #endregion

        #region Unity Methods
        private void Awake()
        {
#if UNITY_EDITOR
            Cursor.lockState = CursorLockMode.Confined;
#endif
        }

        private void Update()
        {
            //if UI is active don't get any input
            if ( UI.UIManager.Instance.nonGameplayUIIsOpen )
                return;

            if ( Input.GetMouseButtonDown( 0 ) )
            {
                onMouseDownCoordinates = Input.mousePosition;
                EventManager.Invoke_OnMouseInputDown();
            }

            if ( Input.GetMouseButton( 0 ) )
            {
                onMouseStayCoordinates = Input.mousePosition;
                EventManager.Invoke_OnMouseInputStay();
            }

            if ( Input.GetMouseButtonUp( 0 ) )
            {
                onMouseUpCoordinates = Input.mousePosition;
                EventManager.Invoke_OnMouseInputUp();
            }
        }

        #endregion

    }
}

