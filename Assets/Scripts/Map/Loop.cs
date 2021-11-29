using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnPipe.Map
{

    /// <summary>
    /// Loop system only works when game isn't started.
    /// </summary>
    public class Loop : MonoBehaviour
    {
        #region Public Fields
        public bool isLevelStarted = false;
        public  Transform startTransform;
        public  Transform finishTransform;
        #endregion

        #region Serialized Fields


        #endregion

        #region Unity Methods
        
        #endregion
    }
}
