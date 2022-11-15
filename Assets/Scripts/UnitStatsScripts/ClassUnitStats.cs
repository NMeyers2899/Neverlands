using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit Type", menuName = "Unit/Create New Unit Type/Class")]
public class ClassUnitStats : UnitStats
{
    [SerializeField]
    [Tooltip("The type that determines the order of action in battle.")]
    private string _unitType;

    /// <summary>
    /// The type that determines the order of action in battle.
    /// </summary>
    public string UnitType { get { return _unitType; } }
}
