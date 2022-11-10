using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit Type", menuName = "Unit/Create New Unit Type/Class")]
public class ClassUnitStats : UnitStats
{
    [SerializeField]
    [Tooltip("Determines whether or not the unit's attack is magic based or not. " +
        "(Determines whether or not the unit will use Defense or Resistance when reducing damage during an attack.)")]
    private bool _attackIsMagic;

    [SerializeField]
    [Tooltip("The type that determines the order of action in battle.")]
    private string _unitType;

    /// <summary>
    /// Determines whether or not the unit's attack is magic based or not.
    /// (Determines whether or not the unit will use Defense or Resistance when reducing damage during an attack.)
    /// </summary>
    public bool AttackIsMagic { get { return _attackIsMagic; } }

    /// <summary>
    /// The type that determines the order of action in battle.
    /// </summary>
    public string UnitType { get { return _unitType; } }
}
