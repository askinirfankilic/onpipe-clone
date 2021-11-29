using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnPipe.Camera
{
    public enum Axis
    {
        X, Y, Z
    }

    [DisallowMultipleComponent]
    public class CameraController : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField] private Vector3 offset;

        #endregion

        #region Private Fields

        private Transform m_Transform;
        private Transform playerTransform;

        #endregion


        #region Properties

        #endregion

        #region Unity Methods

        private void Awake()
        {
            m_Transform = transform;

        }

        private void Start()
        {
            playerTransform = Player.PlayerMovementController.Instance.m_Transform;
        }

        #endregion


        #region Private Methods

        private void FollowPlayerOnAxis( Axis axis, float followThreshodl = 0 )
        {

            switch ( axis )
            {
                case Axis.X:
                    m_Transform.position = new Vector3( playerTransform.position.x, m_Transform.position.y, m_Transform.position.z ) + offset;
                    break;
                case Axis.Y:
                    m_Transform.position = new Vector3( m_Transform.position.x, playerTransform.position.y, m_Transform.position.z ) + offset;
                    break;
                case Axis.Z:
                    m_Transform.position = new Vector3( m_Transform.position.x, m_Transform.position.y, playerTransform.position.z ) + offset;
                    break;
                default:
                    Debug.LogError( "No axes defined!!" );
                    break;
            }
        }

        #endregion

        private void OnEnable()
        {
            Managers.EventManager.OnPlayerPosChanged += FollowPlayerOnAxis;
        }

        private void OnDisable()
        {
            Managers.EventManager.OnPlayerPosChanged -= FollowPlayerOnAxis;
        }
    }
}
