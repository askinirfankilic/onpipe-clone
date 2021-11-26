using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnPipe.Managers
{
    public class EventManager : MonoBehaviour
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
    }
}
