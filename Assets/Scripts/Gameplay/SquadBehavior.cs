using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquadBehavior : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The list of units within this squad.")]
    private UnitBehavior[] _units = new UnitBehavior[9];

    [SerializeField]
    [Tooltip("The commanding unit of the squad. If they die in battle, the squad is defeated.")]
    private UnitBehavior _commanderUnit;

    /// <summary>
    /// The list of units within this squad.
    /// </summary>
    public UnitBehavior[] Units { get { return _units; } }
}
