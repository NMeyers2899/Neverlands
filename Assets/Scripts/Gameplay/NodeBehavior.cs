using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeBehavior : MonoBehaviour
{
    /// <summary>
    /// Determines whether or not the space is occupied.
    /// </summary>
    private bool _isOccupied = false;

    /// <summary>
    /// The position of this node on the x.
    /// </summary>
    private int _xPos;

    /// <summary>
    /// The position of this node on the y.
    /// </summary>
    private int _yPos;

    /// <summary>
    /// The position of this node on the x.
    /// </summary>
    public int XPos { get { return _xPos; } set { _xPos = value; } }

    /// <summary>
    /// The position of this node on the y.
    /// </summary>
    public int YPos { get { return _yPos; } set { _yPos = value; } }

    public void OccupySpace()
    {
        GameManagerBehavior.Instance.ToggleCondition(_isOccupied);
    }
}
