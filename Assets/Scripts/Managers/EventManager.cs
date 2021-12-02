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

        public static event Action OnPlayerDestroyed;
        public static void Invoke_OnPlayerDestroyed()
        {
            OnPlayerDestroyed?.Invoke();
        }


        #endregion

        #region Level

        public static event Action OnLevelStarted;
        public static void Invoke_OnLevelStarted()
        {
            OnLevelStarted?.Invoke();
        }

        public static event Action OnLevelFinished;
        public static void Invoke_OnLevelFinished()
        {
            OnLevelFinished?.Invoke();
        }

        #endregion

        #region Corn Interaction

        public static event Action OnCornDetection;
        public static void Invoke_OnCornDetection()
        {
            OnCornDetection?.Invoke();
        }

        public static event Action<int> OnCornCalculation;
        public static void Invoke_OnCornCalculation( int totalCornCount )
        {
            OnCornCalculation?.Invoke( totalCornCount );
        }

        #endregion

        #region Game Manager

        public static event Action OnGameStarted;
        public static void Invoke_OnGameStarted()
        {
            OnGameStarted?.Invoke();
        }
        

        #endregion
    }
}
