using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnPipe.Pipe
{

    public enum PipeSize
    {
        Small,
        Medium,
        Large
    }

    [DisallowMultipleComponent]
    public class Pipe : MonoBehaviour
    {

        [System.Serializable]
        public class PipeType
        {
            public PipeSize pipeSize;
            public float pipeScale;
        }
        #region Public Fields

        public PipeType pipeType;

        #endregion

        #region Unity Methods
        
        private void OnTriggerEnter( Collider other )
        {
            if ( other.CompareTag( Tags.Player ) )
            {
                // calculate minimum safe radius
                Player.PlayerBehavior playerBehavior = other.GetComponent<Player.PlayerBehavior>();
                Managers.EventManager.Invoke_OnMinimumSafeRadiusChange( pipeType.pipeScale );
                playerBehavior.RefreshPipeProperties( playerBehavior.currentPipeSize, pipeType );
                //update current pipe size
                playerBehavior.currentPipeSize = pipeType.pipeSize;
            }

        }

        #endregion

    }
}
