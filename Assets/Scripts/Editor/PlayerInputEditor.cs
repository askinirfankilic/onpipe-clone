using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif


namespace OnPipe.EditorScript
{
    [CustomEditor( typeof( Player.PlayerInput ) )]
    public class PlayerInputEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
        }
    }
}
