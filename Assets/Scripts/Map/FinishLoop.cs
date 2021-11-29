using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnPipe
{
    public class FinishLoop : MonoBehaviour
    {
        private void OnTriggerEnter( Collider other )
        {
            if ( other.CompareTag( Tags.Player ) )
            {
                GameObject player = other.gameObject;
                OnPlayerInteraction( player );
                

            }
        }

        private void OnPlayerInteraction(GameObject player)
        {
            player.transform.position = gameObject.GetComponentInParent<Loop>().startTransform.position;
        }
    }
}
