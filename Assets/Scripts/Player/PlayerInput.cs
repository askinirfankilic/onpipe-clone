using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OnPipe.Managers;

namespace OnPipe.Player
{
    [DisallowMultipleComponent]
    public class PlayerInput : MonoSingleton<PlayerInput>
    {
        #region Public Fields
        [Header("SCREEN POSITIONS")]
        public Vector2 onMouseDownCoordinates;
        public Vector2 onMouseStayCoordinates;
        public Vector2 onMouseUpCoordinates;

        #endregion

        #region Unity Methods
        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Confined;
        }

        private void Update()
        {

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

