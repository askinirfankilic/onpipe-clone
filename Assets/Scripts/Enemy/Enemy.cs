using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnPipe.Enemy
{
    [DisallowMultipleComponent]
    public class Enemy : MonoBehaviour, Interfaces.IKillable
    {
        public void Kill(GameObject player)
        {
            player.GetComponent<Player.PlayerBehavior>().DestroyItself();
        }
    }
}
