using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct UnitData
{
    [Header("Base Stats")]
    [Tooltip("The maximum health of the unit.")]
    [Range(1, 20)]
    public float MaxHealth;

    [Tooltip("The attack power of the unit.")]
    [Range(1, 20)]
    public float AttackPower;

    [Tooltip("The magic power of the unit.")]
    [Range(1, 20)]
    public float MagicPower;

    [Tooltip("The defense power of the unit. Meant to resist another unit's attack.")]
    [Range(1, 20)]
    public float DefensePower;

    [Tooltip("The resistance power of the unit. Meant to resist another unit's magic.")]
    [Range(1, 20)]
    public float ResistancePower;

    [Tooltip("The skill of the unit, determining how often it can hit an attack, get critical hits, or dodge an attack.")]
    [Range(1, 20)]
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
    [Tooltip("The name of the specific unit type.")]
    private string _unitTypeName;

    [SerializeField]
    private float[] _unitBaseStats = new float[6];

    [SerializeField]
    [Tooltip("The following determines the rate at which each stat will grow for a unit during a level up (calculated as a percentage).\n" +
             "0 : The maximum health of the unit.\n" +
             "1 : The attack power of the unit.\n" +
             "2 : The magic power of the unit.\n" +
             "3 : The defense power of the unit. Meant to resist another unit's attack.\n" +
             "4 : The resistance power of the unit. Meant to resist another unit's magic.\n" +
             "5 : The skill of the unit, determining how often it can hit an attack, get critical hits, or dodge an attack.")]
    [Range(1, 100)]
    private float[] _unitStatApptitudes = new float[6];

    [SerializeField]
    private UnitData _unitData;

    /// <summary>
    /// The name of the specific unit type.
    /// </summary>
    public string UnitTypeName { get { return _unitTypeName;} }

    /// <summary>
    /// The base stats of a given unit type, which represent the following. 
    /// 0 : The maximum health of the unit.
    /// 1 : The attack power of the unit.
    /// 2 : The magic power of the unit.
    /// 3 : The defense power of the unit. Meant to resist another unit's attack.
    /// 4 : The resistance power of the unit. Meant to resist another unit's magic.
    /// 5 : The skill of the unit, determining how often it can hit an attack, get critical hits, or dodge an attack.
    /// </summary>
    public float[] UnitBaseStats { get { return _unitBaseStats; } }

    /// <summary>
    /// The following determines the rate at which each stat will grow for a unit during a level up (calculated as a percentage).
    /// 0 : The maximum health of the unit.
    /// 1 : The attack power of the unit.
    /// 2 : The magic power of the unit.
    /// 3 : The defense power of the unit. Meant to resist another unit's attack.
    /// 4 : The resistance power of the unit. Meant to resist another unit's magic.
    /// 5 : The skill of the unit, determining how often it can hit an attack, get critical hits, or dodge an attack.
    /// </summary>
    public float[] UnitStatApptitudes { get { return _unitStatApptitudes; } }
}
