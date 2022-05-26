using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerBehavior : MonoBehaviour
{
    private static GameManagerBehavior _instance;

    public static GameManagerBehavior Instance
    {
        get 
        {
            if (_instance)
                return _instance;
            else
                return _instance = new GameManagerBehavior();
        }
    }

    /// <summary>
    /// Toggles a boolean variable to true or false depending on what it currently is.
    /// </summary>
    /// <param name="condition"> The boolean being assigned a new value. </param>
    /// <returns> What the boolean is after toggling. </returns>
    public bool ToggleCondition(bool condition)
    {
        if (condition)
            condition = false;
        else
            condition = true;

        return condition;
    }
}
