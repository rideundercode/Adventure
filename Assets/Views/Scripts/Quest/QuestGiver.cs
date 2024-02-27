using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    #region Class Attributes

    /// <summary>
    ///     Initialize A Quest Object;
    /// </summary>
    public Quest quest;

    /// <summary>
    ///     Initialize A Simple Quest Panel;
    /// </summary>
    public GameObject questPanel;

    /// <summary>
    ///     Initialize A Taxt Array which contains all Infos about Quests that we want to display
    /// </summary>
    public Text[] questInfos;

    /// <summary>
    ///     Initialize A String which is the message that will be displayed when quest is completed
    /// </summary>
    public string questCompletedMsg;

    /// <summary>
    ///     Initialize Int XP (how much XP hero character will earn if he completes the quest)
    /// </summary>
    public int xp = 50;

    /// <summary>
    ///     Initialize Int PO (how much PO hero character will earn if he completes the quest)
    /// </summary>
    public int po = 500;

    /// <summary>
    ///     Initialize A GameObject Array which Contains all gameObjects we want to hide after a quest is completed
    /// </summary>
    public GameObject[] toHideAfterQuestCompleted;
    #endregion

    #region Public methods
    /// <summary>
    ///     Function which hides an active object 
    /// </summary>
    public void HideObjectAfterQuest()
    {
        foreach (GameObject go in toHideAfterQuestCompleted)
        {
            go.SetActive(false);
        }
    }
    #endregion
}