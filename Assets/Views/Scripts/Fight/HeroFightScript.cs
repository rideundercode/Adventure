using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using quest_web.Views.Common;

namespace quest_web.Views.Script.Fight
{
    public class HeroFightScript : MonoBehaviour
    {
        #region Class Attributes

        /// <summary>
        ///     Initialize Hero Lifepoints
        /// </summary>
        public int vie = 10;

        /// <summary>
        ///     Initialize Hero Strength
        /// </summary>
        public int force = 2;

        /// <summary>
        ///     Initialize Hero's enemy (mob)
        /// </summary>
        public GameObject enemy;

        /// <summary>
        ///     Initialize Hero's initial position
        /// </summary>
        Vector3 initialPos;

        /// <summary>
        ///     Initialize Hero's enemyScript Script to call its functions
        /// </summary>
        EnemyScript enemyScript;

        /// <summary>
        ///     Initialize boolean that checks if the heroCharacter can fight or not
        /// </summary>
        public bool canFight = true;

        /// <summary>
        ///     Initialize fight camera
        /// </summary>
        public GameObject camFight;

        /// <summary>
        ///     Initialize base Enemy (from scene)
        /// </summary>
        public GameObject baseEnemy;
        #endregion

        #region Private Methods
        void Start()
        {
            initialPos = transform.position;
            enemyScript = enemy.GetComponent<EnemyScript>();
        }
        #endregion

        #region Public Methods

        /// <summary>
        ///     Call The Attack function 
        /// </summary>
        public void Atk1()
        {
            if (canFight)
            {
                StartCoroutine("PlayAtk");
                canFight = false;
            }
        }

        /// <summary>
        ///     Function with which player can attack his enemy(with moves)
        /// </summary>
        IEnumerator PlayAtk()
        {
            iTween.MoveTo(gameObject, enemy.transform.position, 0.4f);
            enemyScript.vie -= force;
            enemyScript.SetLifeBar();
            yield return new WaitForSeconds(0.45F);
            iTween.MoveTo(gameObject, initialPos, 0.8f);

            if (enemyScript.vie <= 0)
            {
                MobBehaviour mobBehaviiour = baseEnemy.GetComponent<MobBehaviour>();
                if (mobBehaviiour.loot != null)
                {
                    mobBehaviiour.DropLoot();
                }
                enemy.SetActive(false);
                baseEnemy.SetActive(false);
                yield return new WaitForSeconds(0.45F);
                camFight.SetActive(false);
            }
            enemyScript.AtkHero();
        }
        #endregion

    }
}