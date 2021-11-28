using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnPipe.Destructibles
{
    public class Corn : MonoBehaviour, IDestructible
    {
        #region Public Fields

        #endregion

        #region Serialized Fields

        [SerializeField] private GameObject particlePrefab;
        [SerializeField] private GameObject visualPrefab;

        #endregion

        #region Private Fields

        private ParticleSystem particle;
        private MeshRenderer meshRenderer;
        #endregion

        #region Properties

        #endregion

        #region Unity Methods

        private void Awake()
        {
            particle = particlePrefab.GetComponent<ParticleSystem>();
            meshRenderer = visualPrefab.GetComponent<MeshRenderer>();
        }
        private void OnTriggerEnter( Collider other )
        {
            if ( other.CompareTag( Tags.Player ) )
            {
                DestroyItself();
            }
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

        private void OnEnable()
        {

        }

        private void OnDisable()
        {

        }

        private void OnDestroy()
        {
            Debug.Log( "Destroyed:  " + gameObject.name);
        }


    }
}
