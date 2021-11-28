using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif


namespace OnPipe
{
    [CustomEditor( typeof( Player.PlayerBehavior ) )]
    public class PlayerBehaviorEditor : Editor
    {
        #region Private Fields

        private Settings.PlayerBehaviorSettings settings;

        #endregion

        #region Unity Methods
        
        private void OnEnable()
        {
            settings = Resources.Load( "Default Player Behavior" ) as Settings.PlayerBehaviorSettings;
            Managers.EventManager.Invoke_OnMinimumSafeRadiusChange( settings.minSafeRadius );

        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            using ( new EditorGUILayout.HorizontalScope() )
            {
                EditorGUILayout.LabelField( "Minimum Safe Radius: " );

                EditorGUI.BeginChangeCheck();
                settings.minSafeRadius = EditorGUILayout.Slider( settings.minSafeRadius, 0.1f, 1f );
                if ( EditorGUI.EndChangeCheck() )
                {
                    Player.PlayerBehavior.MinSafeRadius = settings.minSafeRadius;
                    Managers.EventManager.Invoke_OnMinimumSafeRadiusChange( Player.PlayerBehavior.MinSafeRadius );
                }
            }



        }

        #endregion

    }
}
