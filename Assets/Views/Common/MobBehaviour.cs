using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace quest_web.Views.Common
{

    public class MobBehaviour : MonoBehaviour
    {
        #region ClassAttributes

        /// <summary>
        ///     Initialize an array of Transform Objects
        /// </summary>
        public Transform[] pathPoints;

        /// <summary>
        ///     Initialize X,Y direction vector2
        /// </summary>
        Vector2 dir;

        /// <summary>
        ///     Initialize the speed of the mob
        /// </summary>
        public float speed;

        /// <summary>
        ///     Initialize the SpriteRenderer(mob one)
        /// </summary>
        public SpriteRenderer sr;

        /// <summary>
        ///     Initialize loot GameObject(for recompense)
        /// </summary>
        public GameObject loot;
        #endregion

        #region Private Methods inherited from MonoBehaviour

        /// <summary>
        ///     Initialize the mob's direction to make its moving on the right
        /// </summary>
        void Start()
        {
            dir = Vector2.right;
        }

        /// <summary>
        ///     Updates the mob to make its moving on the right, stopping when he enters in second path point and make him flip on the other side
        /// </summary>
        void Update()
        {
            transform.Translate(dir * speed * Time.deltaTime);
            if (transform.position.x > pathPoints[1].position.x)
            {
                dir = Vector2.left;
                sr.flipX = true;
            }
            if (transform.position.x < pathPoints[0].position.x)
            {
                dir = Vector2.right;
                sr.flipX = false;
            }
        }
        #endregion

        #region Public Methods

        /// <summary>
        ///     Function which invokes the loot when character beats the second mob
        /// </summary>
        public void DropLoot()
        {
            Instantiate(loot, transform.position, Quaternion.identity);
        }
        #endregion

    }
}