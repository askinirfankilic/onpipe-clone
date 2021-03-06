using UnityEngine;
using DG.Tweening;

namespace OnPipe.Camera
{
    /// <summary>
    /// Different camera axis for linear movement.
    /// </summary>
    public enum Axis
    {
        X, Y, Z
    }

    [DisallowMultipleComponent]
    public class CameraController : MonoBehaviour
    {
        [System.Serializable]
        public class FinishCamera
        {
            public float finishYOffset;
            public Ease onFinishEase;
            public float duration;
        }

        #region Serialized Fields

        [SerializeField] private Vector3 offset;
        [SerializeField] private FinishCamera finishCamera;

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
            DOTween.Init();
        }

        private void Start()
        {
            playerTransform = Player.PlayerMovementController.Instance.m_Transform;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Move around y axis for a while.
        /// </summary>
        private void OnFinish()
        {
            Managers.EventManager.OnPlayerPosChanged -= FollowPlayerOnAxis;
            m_Transform.DOMoveY( m_Transform.position.y + finishCamera.finishYOffset, finishCamera.duration ).SetEase( finishCamera.onFinishEase );
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Follow player around one axis.
        /// </summary>
        /// <param name="axis">Axis that being followed.</param>
        /// <param name="followThreshold">A value for how hard camera going to follow player.</param>
        private void FollowPlayerOnAxis( Axis axis, float followThreshold = 0 )
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
            Managers.EventManager.OnLevelFinished += OnFinish;
        }

        private void OnDisable()
        {
            Managers.EventManager.OnPlayerPosChanged -= FollowPlayerOnAxis;
            Managers.EventManager.OnLevelFinished -= OnFinish;
        }
    }
}
