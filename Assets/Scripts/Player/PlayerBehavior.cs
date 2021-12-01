using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
#if UNITY_EDITOR
using UnityEditor;
#endif


namespace OnPipe.Player
{


    [DisallowMultipleComponent, RequireComponent( typeof( PlayerMovementController ), typeof( PlayerInput ) )]
    public class PlayerBehavior : MonoBehaviour, Interfaces.IDestructible
    {
        #region Public Fields
        [Header( "WIN/LOSE" )]
        public Pipe.PipeSize currentPipeSize;
        [HideInInspector]public Animator playerAnim;

        #endregion

        #region Serialized Fields
        [Header( "CONTROL" )]
        [SerializeField] private float scaleDOWNDuration;
        [SerializeField] private float scaleUPDuration;

        [Header( "REFERENCES" )]
        [SerializeField] private MeshRenderer playerVisualRenderer;
        [SerializeField] private ParticleSystem playerDeathParticle;
        [SerializeField] private ParticleSystem playerWindlinesParticle;
        #endregion

        #region Private Fields

        private PlayerMovementController playerMovement;
        private Transform m_Transform;
        private static float minSafeRadius;
        private bool canScaleDown;

        int scaleDownAnimHash;
        int scaleUpAnimHash;
        int failOrWinAnimHash;

        #endregion

        #region Properties

        public static float MinSafeRadius { get => minSafeRadius; set => minSafeRadius = value; }

        #endregion

        #region Unity Methods

        private void Awake()
        {
            m_Transform = transform;
            playerMovement = GetComponent<PlayerMovementController>();
            DOTween.Init();

            playerAnim = GetComponent<Animator>();
            scaleDownAnimHash = Animator.StringToHash( AnimParams.ScaleDown );
            scaleUpAnimHash = Animator.StringToHash( AnimParams.ScaleUp );
            failOrWinAnimHash = Animator.StringToHash( AnimParams.FailOrWin );

        }

        #endregion

        #region Public Methods

        public void RefreshPipeProperties( Pipe.PipeSize previousPipeSize, Pipe.Pipe.PipeType pipeType )
        {
            ChangeMinScale( pipeType );
            if ( previousPipeSize == Pipe.PipeSize.Large && pipeType.pipeSize == Pipe.PipeSize.Medium )
            {
                canScaleDown = true;
                // previous large and current is medium
            }
            else if ( previousPipeSize == Pipe.PipeSize.Large && pipeType.pipeSize == Pipe.PipeSize.Small )
            {
                canScaleDown = true;

                // previous large and current is small
            }
            else if ( previousPipeSize == Pipe.PipeSize.Medium && pipeType.pipeSize == Pipe.PipeSize.Small )
            {
                canScaleDown = true;

                //previous medium and current is small
            }
        }

        private void ChangeMinScale( Pipe.Pipe.PipeType pipeType )
        {
            switch ( pipeType.pipeSize )
            {
                case Pipe.PipeSize.Small:
                    UpdateMinimumSafeRadiusChange( pipeType.pipeScale );
                    break;
                case Pipe.PipeSize.Medium:
                    UpdateMinimumSafeRadiusChange( pipeType.pipeScale );
                    break;
                case Pipe.PipeSize.Large:
                    UpdateMinimumSafeRadiusChange( pipeType.pipeScale );
                    break;
                default:
                    break;
            }
        }

        public void DestroyItself()
        {
            playerMovement.Stop();
            playerAnim.SetTrigger( failOrWinAnimHash );
            playerWindlinesParticle.Stop();
            StartCoroutine( WaitForEndOfParticlePlay() );
        }

        public void OnFinish()
        {
            Debug.Log( "Finish" );
            playerAnim.SetTrigger( failOrWinAnimHash );
        }

        #endregion

        #region Private Methods

        private void OnPlayerInputDown()
        {
            ScaleDown( MinSafeRadius );
            playerAnim.SetTrigger( scaleDownAnimHash );
            playerWindlinesParticle.Play();
        }

        private void OnPlayerInputStay()
        {
            if ( canScaleDown )
            {
                ScaleDown( minSafeRadius );
                canScaleDown = false;
            }
        }

        private void OnPlayerInputUp()
        {
            ScaleUp();
            playerAnim.SetTrigger( scaleUpAnimHash );

        }

        private void ScaleDown( float minRadius )
        {
            Vector3 scaleVector = new Vector3( minRadius, 1, minRadius );
            m_Transform.DOScale( endValue: scaleVector, duration: scaleDOWNDuration );
        }

        private void ScaleUp()
        {
            Vector3 scaleVector = Vector3.one;
            m_Transform.DOScale( endValue: scaleVector, duration: scaleUPDuration );
        }

        private void UpdateMinimumSafeRadiusChange( float minimumSafeRadiusChange )
        {
            MinSafeRadius = minimumSafeRadiusChange;
        }

        private IEnumerator WaitForEndOfParticlePlay()
        {
            if ( playerDeathParticle != null && playerVisualRenderer != null )
            {
                playerVisualRenderer.enabled = false;
                playerDeathParticle.Play();
                yield return new WaitForSeconds( playerDeathParticle.main.duration );
                Destroy( gameObject );
            }
        }

        #endregion

        #region Editor Methods

#if UNITY_EDITOR

        private void OnDrawGizmos()
        {
            Handles.color = Color.red;

            Handles.Label( transform.position, text: "Minimum Safe Radius: " + MinSafeRadius );
            Handles.zTest = UnityEngine.Rendering.CompareFunction.Always;

            Handles.DrawWireDisc( transform.position, transform.up, MinSafeRadius );
        }

#endif

        #endregion



        private void OnEnable()
        {
            Managers.EventManager.OnMouseInputDown += OnPlayerInputDown;
            Managers.EventManager.OnMouseInputStay += OnPlayerInputStay;
            Managers.EventManager.OnMouseInputUp += OnPlayerInputUp;
            Managers.EventManager.OnMinimumSafeRadiusChanged += UpdateMinimumSafeRadiusChange;
        }



        private void OnDisable()
        {
            Managers.EventManager.OnMouseInputDown -= OnPlayerInputDown;
            Managers.EventManager.OnMouseInputStay -= OnPlayerInputStay;
            Managers.EventManager.OnMouseInputUp -= OnPlayerInputUp;
            Managers.EventManager.OnMinimumSafeRadiusChanged -= UpdateMinimumSafeRadiusChange;

        }


    }
}
