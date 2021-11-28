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
        public PipeSize pipeSize;

        private void Awake()
        {
            if ( pipeSize == null )
            {
                Debug.LogError( "Pipe Size is null" );
            }
        }

    }
}
