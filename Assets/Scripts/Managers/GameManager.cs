using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnPipe.Managers
{
    public class GameManager : MonoSingleton<GameManager>
    {
        private bool isGameStarted = false;

        public bool IsGameStarted { get => isGameStarted; set => isGameStarted =  value ; }
    }
}
