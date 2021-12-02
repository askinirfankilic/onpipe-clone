using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnPipe.Map
{
    public class FinishLoop : MonoBehaviour
    {
        #region Unity Methods

        private void OnTriggerEnter( Collider other )
        {
            if ( other.CompareTag( Tags.Player ) )
            {
                GameObject player = other.gameObject;
                OnPlayerInteraction( player );
            }
        }

        #endregion

        #region Private Methods

        private void OnPlayerInteraction( GameObject player )
        {
            //Move to start position of loop
            player.transform.position = gameObject.GetComponentInParent<Loop>().startTransform.position;
        }

        #endregion

    }
}
