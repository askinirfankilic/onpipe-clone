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
        [SerializeField] private bool isStopped = false;

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
            //If player has stopped dont change pos and do onplayermovestopped. 
            if ( isStopped )
            {
                Managers.EventManager.Invoke_OnPlayerMoveStopped();
            }
            else
            {
                Move( speed );
                Managers.EventManager.Invoke_OnPlayerPosChanged( axis: Camera.Axis.Y, followThreshold: 0 );

            }
        }

        #endregion
        #region Public Methods

        public void Move( float speed )
        {
            m_Transform.Translate( Vector3.up * speed * Time.deltaTime );
        }

        public void Stop()
        {
            isStopped = true;
        }



        #endregion

        #region Private Methods
        private void OnFinish()
        {
            //move faster
            speed += 5f;
        }

        #endregion

        private void OnEnable()
        {
            Managers.EventManager.OnLevelFinished += OnFinish;
        }

        private void OnDisable()
        {
            Managers.EventManager.OnLevelFinished -= OnFinish;
        }

    }
}
