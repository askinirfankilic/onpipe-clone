using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnPipe.Player.Detection
{
    public class Detection : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField, Range( 0.01f, 1f )] private float detectionRange;

        #endregion
        #region Private Fields

        private int layerMask;
        private PlayerBehavior playerBehavior;
        private bool playerAlreadyDestroyed = false;

        private int previousCornHash;
        #endregion

        #region Unity Methods

        private void Awake()
        {
            //Layermask preparation
            string cornLayer = LayerMask.LayerToName( Layers.Corn );
            string enemyLayer = LayerMask.LayerToName( Layers.Enemy );
            string pipeLayer = LayerMask.LayerToName( Layers.Pipe );
            layerMask = LayerMask.GetMask( cornLayer, enemyLayer, pipeLayer );

            playerBehavior = GetComponentInParent<PlayerBehavior>();
        }

        private void FixedUpdate()
        {
            Detect();
        }


        #region Editor Methods

        private void OnDrawGizmos()
        {
            Gizmos.DrawRay( transform.position, transform.up * detectionRange );
        }

        #endregion

        #endregion

        #region Private Methods

        private void Detect()
        {

            RaycastHit hit;
            if ( Physics.Raycast( transform.position, transform.up, out hit, detectionRange, layerMask ) )
            {
                if ( hit.transform.CompareTag( Tags.Corn ) && hit.transform.GetInstanceID() != previousCornHash )
                {
                    previousCornHash = hit.transform.GetInstanceID();
                    Managers.EventManager.Invoke_OnCornDetection();
                    Destructibles.Corn corn = hit.transform.GetComponent<Destructibles.Corn>();
                    corn.DestroyItself();
                }
                else if ( hit.transform.CompareTag( Tags.Enemy ) && !playerAlreadyDestroyed )
                {
                    playerBehavior.DestroyItself();
                    playerAlreadyDestroyed = true;
                }
                else if ( hit.transform.CompareTag( Tags.Pipe ) && !playerAlreadyDestroyed )
                {
                    //same code usage is intended
                    playerBehavior.DestroyItself();
                    playerAlreadyDestroyed = true;
                }
            }
        }


        #endregion
    }
}
