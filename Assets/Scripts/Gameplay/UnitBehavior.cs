using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBehavior : MonoBehaviour
{
    /// <summary>
    /// The stats of the unit.
    /// </summary>
    private UnitStats _unitStats;

    /// <summary>
    /// Checks to see whether or not the unit belongs to the player.
    /// </summary>
    private bool _isPlayerUnit;

    /// <summary>
    /// The stats of the unit.
    /// </summary>
    public UnitStats UnitStats { get { return _unitStats; } }
}
