using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using quest_web.Models;
using quest_web.Views.Script.Fight;

namespace quest_web.Views.Common
{
    public class HeroCharacterCollisions : MonoBehaviour
    {
        #region ClassAttributes

        /// <summary>
        ///     Initialize a simple dialWorldSpace GameObject
        /// </summary>
        public GameObject dialWorldSpace;

        /// <summary>
        ///     Initialize a simple dialText
        /// </summary>
        public TMP_Text dialTxt;

        /// <summary>
        ///     Defines an object which will be the object which collides with our hero character
        /// </summary>
        Collider2D otherObj;

        /// <summary>
        ///     Initialize a simple dialog canvas
        /// </summary>
        public GameObject dialCanvas;

        /// <summary>
        ///     Initialize a simple dialog canvas Text
        /// </summary>
        public Text dialCanvasTxt;

        /// <summary>
        ///     Initialize a QuestGivers array
        /// </summary>
        public QuestGiver[] quests;

        /// <summary>
        ///     Initialize a camera GameObject dedicated to fight the enemy
        /// </summary>
        public GameObject camFight;

        #endregion

        #region PrivateMethods inherited from MonoBehaviour

        /// <summary>
        ///     Defines all actions if the heroCharacter enters in contact with another gameObject whoch got an active trigger
        /// </summary>
        /// <param name="other">Collider2D</param>
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "sign")
            {
                otherObj = other;
                //dialWorldSpace.SetActive(true);
                SignBehaviour sb = other.gameObject.GetComponent<SignBehaviour>();
                //dialTxt.SetText(sb.signText);
                sb.ui.SetActive(true);
            }
            if (other.gameObject.tag == "flower")
            {
                otherObj = other;
                otherObj.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            }
            if (other.gameObject.tag == "exit")
            {
                string point = other.gameObject.GetComponent<ExitBehaviour>().teleportPoint;
                PlayerPrefs.SetString("Point", point);
                Application.LoadLevel(other.gameObject.name);
            }
            if (other.gameObject.tag == "mob" && !camFight.activeInHierarchy)
            {
                print("Combat");
                camFight.SetActive(true);
                InitializeFight initFight = camFight.GetComponent<InitializeFight>();
                initFight.heroFightScript.baseEnemy = other.gameObject;
                initFight.initFight();
            }
            if (other.gameObject.tag == "coin")
            {
                Destroy(other.gameObject);
            }
        }

        /// <summary>
        ///     Defines all actions if the heroCharacter stops the contact with another gameObject which got an active trigger
        /// </summary>
        /// <param name="other">Collider2D</param>
        void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.tag == "sign")
            {
                SignBehaviour sb = other.gameObject.GetComponent<SignBehaviour>();
                sb.ui.SetActive(false);
                otherObj = null;
                Invoke("HideDialPanel", 1);
            }
            if (other.gameObject.tag == "flower")
            {
                otherObj.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                otherObj = null;
            }
        }

        /// <summary>
        ///     Defines all actions if the heroCharacter enters in contact with another gameObject
        /// </summary>
        /// <param name="other">Collision2D</param>
        void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == "garde")
            {
                ShowDialCanvasTxt(other.gameObject.GetComponent<PnjSimpleDial>().simpleDial);
            }
        }

        /// <summary>
        ///     Defines all actions if the heroCharacter stops the contact with another gameObject
        /// </summary>
        /// <param name="other">Collider2D</param>
        void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.tag == "garde")
            {
                HideDialCanvas();
            }
        }

        /// <summary>
        ///     Update HeroCharacterAction if E(keyboard) is pressed
        /// </summary>
        void Update()
        {
            if (Input.GetKeyUp(KeyCode.E) && otherObj != null)
            {
                if (otherObj.gameObject.tag == "sign")
                {
                    ShowDial();
                }
                if (otherObj.gameObject.tag == "flower")
                {
                    if (quests[0].quest.isActive)
                    {
                        ShowDialCanvasTxt("Count : " + quests[0].quest.count);
                        quests[0].quest.IncrementCount();
                    }
                    otherObj.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                    otherObj.gameObject.SetActive(false);
                    otherObj = null;

                }
            }
        }
        #endregion

        #region Public Methods

        /// <summary>
        ///     Hide the simple dialog panel 
        /// </summary>
        public void HideDialPanel()
        {
            dialWorldSpace.SetActive(false);

        }

        /// <summary>
        ///     Get the text 
        /// </summary>
        public void ShowDial()
        {
            SignBehaviour sb = otherObj.gameObject.GetComponent<SignBehaviour>();
            sb.ui.SetActive(false);
            dialWorldSpace.SetActive(true);
            dialTxt.SetText(sb.signText);
        }

        /// <summary>
        ///     Show the simple dialog Canvas text 
        /// </summary>
        public void ShowDialCanvasTxt(string msg)
        {
            dialCanvas.SetActive(true);
            dialCanvasTxt.text = msg;
        }

        /// <summary>
        ///     Show the simple dialog Canvas
        /// </summary>
        public void HideDialCanvas()
        {
            dialCanvas.SetActive(false);
        }
        #endregion
    }
}