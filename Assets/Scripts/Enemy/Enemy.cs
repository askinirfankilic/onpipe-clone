using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnPipe.Enemy
{
    /// <summary>
    /// Defines a killable enemy when interacted.
    /// </summary>
    [DisallowMultipleComponent]
    public class Enemy : MonoBehaviour, Interfaces.IKillable
    {
        public void Kill(GameObject player)
        {
            player.GetComponent<Player.PlayerBehavior>().DestroyItself();
        }
    }
}
