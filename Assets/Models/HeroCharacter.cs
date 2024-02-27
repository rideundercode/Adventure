using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace quest_web.Models
{

    public class HeroCharacter : MonoBehaviour
    {
        #region ClassAttributes

        /// <summary>
        ///     Initialize the Hero Character's MoveSpeed
        /// </summary>
        public float moveSpeed = 5.0f;

        /// <summary>
        ///     Initialize a rigidbody Object
        /// </summary>
        public Rigidbody2D rb;

        /// <summary>
        ///     Initialize an Animator Object
        /// </summary>
        public Animator animator;

        /// <summary>
        ///     Initialize a SpriteRenderer Object
        /// </summary>
        public SpriteRenderer spriteRenderer;

        /// <summary>
        ///     Initialize a Vector2 Object
        /// </summary>
        Vector2 dir;

        /// <summary>
        ///     Initialize cardinality
        /// </summary>
        int dirValue = 0; //0 = Idl,  1 = Down,  2 = side,  3 = Up
        #endregion

        #region private functions

        /// <summary>
        ///     private Method Herited from Parent class
        /// </summary>
        // Update is called once per frame
        void Update()
        {
            HandleKeys();
            HandleMove();
        }

        #endregion

        #region public functions

        /// <summary>
        ///     manages the HeroCharacter Moves in Space
        /// </summary>
        public void HandleKeys()
        {
            if (Input.GetKey(KeyCode.DownArrow))  //Descendre 
            {
                dir = Vector2.down;
                dirValue = 1;

            }
            else if (Input.GetKey(KeyCode.UpArrow)) //Monter
            {
                dir = Vector2.up;
                dirValue = 3;
            }
            else if (Input.GetKey(KeyCode.RightArrow))  //Droite
            {
                dir = Vector2.right;
                dirValue = 2;
                spriteRenderer.flipX = true;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))  //Gauche
            {
                dir = Vector2.left;
                dirValue = 2;
                spriteRenderer.flipX = false;

            }
            else  //rien
            {
                dir = Vector2.zero;
            }

        }
        /// <summary>
        ///     Make the character move from its position depending on its moveSpeed
        /// </summary>
        public void HandleMove()
        {
            rb.MovePosition(rb.position + dir * moveSpeed * Time.fixedDeltaTime);
            animator.SetInteger("dir", dirValue);
        }
        #endregion
    }
}