using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace quest_web.Views.Common
{

    public class HeroBehaviour : MonoBehaviour
    {

        #region Private Methods

        /// <summary>
        ///     Set the Monobehaviour inherated Awake function to tp the heroCharacter from Point 1 to Point 2
        /// </summary>
        void Awake()
        {
            string point = PlayerPrefs.GetString("Point", "Point_1");
            Vector3 teleportPosition = GameObject.Find(point).transform.position;
            transform.position = teleportPosition;
        }
        #endregion

    }
}