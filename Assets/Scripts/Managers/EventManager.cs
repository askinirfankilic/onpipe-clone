using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnPipe.Managers
{
    public class EventManager
    {
        #region Mouse Inputs

        public static event Action OnMouseInputDown;
        public static void Invoke_OnMouseInputDown()
        {
            OnMouseInputDown?.Invoke();
        }

        public static event Action OnMouseInputStay;
        public static void Invoke_OnMouseInputStay()
        {
            OnMouseInputStay?.Invoke();
        }

        public static event Action OnMouseInputUp;
        public static void Invoke_OnMouseInputUp()
        {
            OnMouseInputUp?.Invoke();
        }

        #endregion

        #region Player Interaction

        public static event Action<Camera.Axis, float> OnPlayerPosChanged;
        public static void Invoke_OnPlayerPosChanged( Camera.Axis axis, float followThreshold )
        {
            OnPlayerPosChanged?.Invoke( axis, followThreshold );
        }

        public static event Action<float> OnMinimumSafeRadiusChanged;
        public static void Invoke_OnMinimumSafeRadiusChange( float minimumSafeRadiusChange )
        {
            OnMinimumSafeRadiusChanged?.Invoke( minimumSafeRadiusChange );
        }

        public static event Action OnPlayerMoveStopped;
        public static void Invoke_OnPlayerMoveStopped()
        {
            OnPlayerMoveStopped?.Invoke();
        }
        #endregion
    }
}
