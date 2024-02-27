using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace quest_web.Views.Script.Fight
{
    public class EnemyScript : MonoBehaviour
    {
        #region Class Attributes

        /// <summary>
        ///     Initialize enemy character life points
        /// </summary>
        public int vie = 3;

        /// <summary>
        ///     Initialize enemy character strength
        /// </summary>
        public int force = 1;

        /// <summary>
        ///     Initialize enemy character lifeBar
        /// </summary>
        public GameObject barreVie;

        /// <summary>
        ///     Initialize hero which will be the enemy's adversary 
        /// </summary>
        public GameObject hero;

        /// <summary>
        ///     Initialize hero which will be the enemy's adversary 
        /// </summary>
        Vector3 initialPos;

        /// <summary>
        ///     Initialize heroFightScript which will bring hero fight script's methods 
        /// </summary>
        HeroFightScript heroFightScript;


        /// <summary>
        ///     Initialize enemy's X lifeBar 
        /// </summary>
        float scaleX;

        #endregion


        #region Private Methods inherited from Mono behaviour

        /// <summary>
        ///     Initialize Enemy's position, hero fight script and the lifeBar X position 
        /// </summary>
        void Start()
        {
            initialPos = transform.position;
            heroFightScript = hero.GetComponent<HeroFightScript>();
            scaleX = barreVie.transform.localScale.x / vie;
        }
        #endregion

        #region Public Methods

        /// <summary>
        ///     Updates the lifeBar X position in function of enemy's life 
        /// </summary>
        public void SetLifeBar()
        {
            barreVie.transform.localScale = new Vector3(scaleX * vie, 0.125f, 1);
        }

        /// <summary>
        ///    Function which calls the PlayAttack
        /// </summary>
        public void AtkHero()
        {
            if (gameObject.activeInHierarchy)
                StartCoroutine("PlayAtk");
        }

        /// <summary>
        ///    Function to attack the hero
        /// </summary>
        IEnumerator PlayAtk()
        {
            yield return new WaitForSeconds(0.5f);
            iTween.MoveTo(gameObject, hero.transform.position, 0.4f);
            heroFightScript.vie -= force;
            yield return new WaitForSeconds(0.3F);
            iTween.MoveTo(gameObject, initialPos, 0.6f);

            if (heroFightScript.vie <= 0)
            {
                //hero.SetActive(false);
                print("Perdu");
            }
            heroFightScript.canFight = true;
        }
        #endregion
    }
}