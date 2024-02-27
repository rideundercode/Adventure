using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Quest
{
    #region ClassAttributes

    /// <summary>
    ///     Initialize Quest title
    /// </summary>
    public string title;

    /// <summary>
    ///     Initialize Quest Description
    /// </summary>
    public string description;

    /// <summary>
    ///     Initialize Quest Recompenses
    /// </summary>
    public int gold;

    /// <summary>
    ///     Initialize Quest XP's for heroCharacter
    /// </summary>
    public int xp;

    /// <summary>
    ///     Initialize a bool which can detect if a quest is active or not
    /// </summary>
    public bool isActive;

    /// <summary>
    ///     Initialize a bool which can detect if a quest is completed or not
    /// </summary>
    public bool isComplete = false;

    /// <summary>
    ///     Initialize string objectType which defines an object type which will be concerned by the quest
    /// </summary>
    public string objType;

    /// <summary>
    ///     Initialize string objectType which defines the number of objectType necessary to validate the quest
    /// </summary>
    public int reqAmount;

    /// <summary>
    ///     Initialize a counter
    /// </summary>
    public int count = 0;
    #endregion

    #region public Methods

    /// <summary>
    ///     Function which increments count variable each time the character gets an objectType property, and set the quest as completed if the count is equal to reqAmount property
    /// </summary>
    public void IncrementCount() 
    {
        count++;
        if(count >= reqAmount)
        {
            isComplete = true;
        }
    }
    #endregion
}
