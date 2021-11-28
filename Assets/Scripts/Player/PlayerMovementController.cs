using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnPipe.Player
{
    [DisallowMultipleComponent, RequireComponent( typeof( PlayerBehavior ), typeof( PlayerInput ) )]
    public class PlayerMovementController : Managers.MonoSingleton<PlayerMovementController>
    {
        #region Public Fields

        [HideInInspector] public Transform m_Transform;

        #endregion

        #region Serialized Fields

        [SerializeField] private float speed;


        #endregion

        #region Private Fields


        #endregion

        #region Properties


        #endregion

        #region Unity Methods

        private void Awake()
        {
            m_Transform = transform;
        }

        private void Update()
        {
            Move();
            Managers.EventManager.Invoke_OnPlayerPosChanged( axis: Camera.Axis.Y, followThreshold: 0 );
        }

        #endregion
        #region Public Methods

        public void Move()
        {
            m_Transform.Translate( Vector3.up * speed * Time.deltaTime );
        }

        #endregion

        #region Private Methods


        #endregion

    }
}
