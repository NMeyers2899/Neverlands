using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The data that can be found within each unit type.
/// </summary>
[System.Serializable]
public struct UnitTypeData
{
    [Header("Name and Description")]
    [Tooltip("The name of the specific unit type.")]
    public string UnitTypeName;

    [Tooltip("A quick description of the unit type, allowing the user to get an idea of its strengths or weaknesses.")]
    public string UnitTypeDescription;

    [Header("Base Stats")]
    [Tooltip("The maximum health of the unit.")]
    [Range(1, 20)]
    public float MaxHealth;

    [Tooltip("The attack power of the unit.")]
    [Range(1, 10)]
    public float AttackPower;

    [Tooltip("The magic power of the unit.")]
    [Range(1, 10)]
    public float MagicPower;

    [Tooltip("The defense power of the unit. Meant to resist another unit's attack.")]
    [Range(1, 10)]
    public float DefensePower;

    [Tooltip("The resistance power of the unit. Meant to resist another unit's magic.")]
    [Range(1, 10)]
    public float ResistancePower;

    [Tooltip("The skill of the unit, determining how often it can hit an attack, get critical hits, or dodge an attack.")]
    [Range(1, 10)]
    public float SkillPower;

    [Header("Apptitudes")]
    [Tooltip("How much (calculated by a percentage) health will be increased on a level up.")]
    [Range(1, 100)]
    public float HealthApptitude;

    [Tooltip("How much (calculated by a percentage) attack will be increased on a level up.")]
    [Range(1, 100)]
    public float AttackApptitude;
    
    [Tooltip("How much (calculated by a percentage) magic will be increased on a level up.")]
    [Range(1, 100)]
    public float MagicApptitude;

    [Tooltip("How much (calculated by a percentage) defense will be increased on a level up.")]
    [Range(1, 100)]
    public float DefenseApptitude;

    [Tooltip("How much (calculated by a percentage) resistance will be increased on a level up.")]
    [Range(1, 100)]
    public float ResistanceApptitude;

    [Tooltip("How much (calculated by a percentage) skill will be increased on a level up.")]
    [Range(1, 100)]
    public float SkillApptitude;
}

[CreateAssetMenu(fileName = "New Unit Type", menuName = "Unit/Create New Unit Type")]
public class UnitStats : ScriptableObject
{
    [SerializeField]
    [Tooltip("The data for a unit type, containing base stats and apptitudes.")]
    private UnitTypeData _unitTypeData;

    /// <summary>
    /// The data for a unit type, containing base stats and apptitudes."
    /// </summary>
    public UnitTypeData UnitTypeData { get { return _unitTypeData;} }
}
