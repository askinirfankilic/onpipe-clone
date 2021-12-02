using UnityEngine;

namespace OnPipe.Settings
{

    [CreateAssetMenu(menuName = "Settings/Player Behavior")]
    public class PlayerBehaviorSettings : ScriptableObject
    {
        public float minSafeRadius;
    }
}
