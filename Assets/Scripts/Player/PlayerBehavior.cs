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
        #endregion

        #region Serialized Fields


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
            m_Transform.DOScale( scaleVector, 0.5f );
        }

        private void ScaleUp()
        {
            Vector3 scaleVector = Vector3.one;
            m_Transform.DOScale( scaleVector, 0.5f );
        }

        private void UpdateMinimumSafeRadiusChange( float minimumSafeRadiusChange )
        {
            MinSafeRadius = minimumSafeRadiusChange;
        }

        #endregion

        #region Editor Methods

#if UNITY_EDITOR

        private void OnDrawGizmosSelected()
        {
            Handles.Label( transform.position, text: "Radius: " + MinSafeRadius );
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
