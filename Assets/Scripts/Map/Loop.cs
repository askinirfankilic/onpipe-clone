using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
namespace OnPipe.Map
{

    /// <summary>
    /// Loop system only works when game isn't started.
    /// </summary>
    public class Loop : MonoBehaviour
    {
        #region Public Fields
        public bool isLevelStarted = false;
        public Transform startTransform;
        public Transform finishTransform;
        #endregion

        #region Serialized Fields


        #endregion

        #region Unity Methods

#if UNITY_EDITOR

        #region Editor Methods
        private void OnDrawGizmosSelected()
        {

            Handles.zTest = UnityEngine.Rendering.CompareFunction.LessEqual;

            Vector3 loopSystemPos = transform.position;
            Vector3 startPos = startTransform.position;
            Vector3 finishPos = finishTransform.position;

            float halfHeightStart = ( loopSystemPos.x - startPos.x ) * 0.5f;
            float halfHeightFinish = ( loopSystemPos.x - finishPos.x ) * 0.5f;

            Vector3 startOffset = Vector3.right * halfHeightStart;
            Vector3 finishOffset = Vector3.right * halfHeightFinish;

            Handles.DrawBezier( loopSystemPos, startPos, loopSystemPos - startOffset, startPos + startOffset, Color.red, EditorGUIUtility.whiteTexture, 1f );
            Handles.DrawBezier( loopSystemPos, finishPos, loopSystemPos - finishOffset, finishPos + finishOffset, Color.green, EditorGUIUtility.whiteTexture, 1f );
        }

        #endregion
#endif

        #endregion
    }
}
