using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnPipe.Destructibles
{
    [DisallowMultipleComponent]
    public class CornManager : MonoBehaviour
    {
        public int cornCount = 0;

        private Transform m_Transform;

        private void Awake()
        {
            m_Transform = transform;
        }
        private void Start()
        {
            //for every pipe
            for ( int i = 0; i < m_Transform.childCount; i++ )
            {
                //for every corn
                Transform pipeTransform = m_Transform.GetChild( i );
                for ( int j = 0; j < pipeTransform.childCount; j++ )
                {
                    //increase corn count
                    cornCount++;
                }
            }

            Managers.EventManager.Invoke_OnCornCalculation( cornCount );


        }
    }
}
