using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnPipe.Player.Detection
{
    public class Detection : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField, Range(0.01f, 1f)] private float detectionRange;

        #endregion

        #region Unity Methods
        private void FixedUpdate()
        {
            int layerMask = 1 << Layers.Corn;

            RaycastHit hit;
            if ( Physics.Raycast(transform.position, transform.up, out hit, detectionRange, layerMask ))
            {
                Destructibles.Corn corn = hit.transform.GetComponent<Destructibles.Corn>();
                corn.DestroyItself();
            }
        }

        #region Editor Methods
        private void OnDrawGizmos()
        {
            Gizmos.DrawRay( transform.position, transform.up * detectionRange );
        }
        #endregion
        #endregion

    }
}
