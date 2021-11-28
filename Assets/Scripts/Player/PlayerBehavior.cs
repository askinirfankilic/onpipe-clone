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
    public class PlayerBehavior : MonoBehaviour
    {
        #region Public Fields

        public Pipe.PipeSize currentPipeSize;

        #endregion

        #region Serialized Fields
        [SerializeField] private float scaleDOWNDuration;
        [SerializeField] private float scaleUPDuration;

        #endregion

        #region Private Fields

        private PlayerMovementController playerMovement;
        private Transform m_Transform;
        private static float minSafeRadius;



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
        }

        #endregion

        #region Public Methods

        public void ChangeMinScale( Pipe.Pipe.PipeType pipeType )
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

        #endregion

        #region Private Methods

        private void OnPlayerInputDown()
        {
            ScaleDown( MinSafeRadius );
        }

        private void OnPlayerInputStay()
        {
            Debug.Log( "Move" );

        }

        private void OnPlayerInputUp()
        {
            ScaleUp();
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


        #endregion

        #region Editor Methods

#if UNITY_EDITOR

        private void OnDrawGizmos()
        {
            Handles.color = Color.red;

            Handles.Label( transform.position, text: "Radius: " + MinSafeRadius );
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
            Managers.EventManager.OnMinimumSafeRadiusChange += UpdateMinimumSafeRadiusChange;
        }



        private void OnDisable()
        {
            Managers.EventManager.OnMouseInputDown -= OnPlayerInputDown;
            Managers.EventManager.OnMouseInputStay -= OnPlayerInputStay;
            Managers.EventManager.OnMouseInputUp -= OnPlayerInputUp;
            Managers.EventManager.OnMinimumSafeRadiusChange -= UpdateMinimumSafeRadiusChange;

        }
    }
}
