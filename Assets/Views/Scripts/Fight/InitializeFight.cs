using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace quest_web.Views.Script.Fight
{
    public class InitializeFight : MonoBehaviour
    {
        #region Class Attributes

        /// <summary>
        ///     Initialize mob Game Object 
        /// </summary>
        public GameObject mob;

        /// <summary>
        ///     Initialize mob Script to call its functions
        /// </summary>
        EnemyScript enemyScript;

        /// <summary>
        ///     Initialize hero Script to call its functions
        /// </summary>
        public HeroFightScript heroFightScript;
        #endregion

        #region Public Methods

        //initialize the fight(clear datas)
        public void initFight()
        {
            mob.SetActive(true);
            enemyScript = mob.GetComponent<EnemyScript>();
            enemyScript.vie = 3;
            heroFightScript.canFight = true;
            enemyScript.SetLifeBar();
        }
        #endregion
    }
}