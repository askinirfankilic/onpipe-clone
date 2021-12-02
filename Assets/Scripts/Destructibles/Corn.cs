using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnPipe.Destructibles
{
    /// <summary>
    /// Defines a corn that can be destructible when interacted.
    /// </summary>
    public class Corn : MonoBehaviour, Interfaces.IDestructible
    {
        #region Serialized Fields

        [SerializeField] private GameObject particlePrefab;
        [SerializeField] private GameObject visualPrefab;

        #endregion

        #region Private Fields

        private ParticleSystem particle;
        private MeshRenderer meshRenderer;

        #endregion

        #region Unity Methods

        private void Awake()
        {
            particle = particlePrefab.GetComponent<ParticleSystem>();
            meshRenderer = visualPrefab.GetComponent<MeshRenderer>();
        }

        #endregion

        #region Public Methods

        public void DestroyItself()
        {
            StartCoroutine( WaitForEndOfParticlePlay() );
        }

        #endregion

        #region Private Methods

        private IEnumerator WaitForEndOfParticlePlay()
        {
            if ( particle != null && meshRenderer != null )
            {
                meshRenderer.enabled = false;
                particle.Play();
                yield return new WaitForSeconds( particle.main.duration );
                Destroy( gameObject );
            }
        }

        #endregion
    }
}
