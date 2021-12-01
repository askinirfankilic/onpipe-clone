using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnPipe.Finish
{
    [DisallowMultipleComponent]
    public class Finish : MonoBehaviour
    {
        #region Serialized Field

        [SerializeField] private ParticleSystem leftConfetti;
        [SerializeField] private ParticleSystem rightConfetti;

        #endregion

        #region Unity Fields

       

        private void OnTriggerEnter( Collider other )
        {

            if ( other.CompareTag( Tags.Player ) )
            {
                Managers.EventManager.Invoke_OnLevelFinished();
                Player.PlayerBehavior playerBehavior = other.GetComponent<Player.PlayerBehavior>();
                playerBehavior.OnFinish();
                PlayConfettis();
            }
        }

        private void PlayConfettis()
        {
            leftConfetti.Play();
            rightConfetti.Play();
        }

        #endregion
    }
}
