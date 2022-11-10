using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit Type", menuName = "Unit/Create New Unit Type")]
public class UnitStats : ScriptableObject
{
    [SerializeField]
    [Tooltip("The name of the specific unit type.")]
    private string _unitTypeName;

    [SerializeField]
    [Tooltip("The maximum possible health of the unit.")]
    private float _maxHealth;

    [SerializeField]
    [Tooltip("How much damage the unit will deal.")]
    private float _attackPower;

    [SerializeField]
    [Tooltip("How resistant the unit is to physical damage.")]
    private float _defensePower;

    [SerializeField]
    [Tooltip("How resistant the unit is to magic damage.")]
    private float _resistancePower;

    [SerializeField]
    [Tooltip("How well the unit is able to dodge incoming attacks.")]
    private float _speedPower;

    [SerializeField]
    [Tooltip("Influences the chance of a unit to hit an opponent.")]
    private float _hitChance;

    [SerializeField]
    [Tooltip("The percentage that stats will increase by on a level up.")]
    private float _healthApptitude, _attackApptitude, _defenseApptitude, _resistanceApptitude, _speedApptitude, _hitApptitude;

    /// <summary>
    /// The name of the specific unit type.
    /// </summary>
    public string UnitTypeName { get { return _unitTypeName; } }

    /// <summary>
    /// The maximum possible health of the unit.
    /// </summary>
    public float MaxHealth { get { return _maxHealth; } }

    /// <summary>
    /// How much damage the unit will deal.
    /// </summary>
    public float AttackPower { get { return _attackPower; } }

    /// <summary>
    /// How resistant the unit is to physical damage.
    /// </summary>
    public float DefensePower { get { return _defensePower; } }

    /// <summary>
    /// How resistant the unit is to magic damage.
    /// </summary>
    public float ResistancePower { get { return _resistancePower; } }

    /// <summary>
    /// How well the unit is able to dodge incoming attacks.
    /// </summary>
    public float SpeedPower { get { return _speedPower; } }

    /// <summary>
    /// Influences the chance of a unit to hit an opponent.
    /// </summary>
    public float HitChance { get { return _hitChance; } }

    /// <summary>
    /// The percentage that health will increase upon a level up.
    /// </summary>
    public float HealthApptitude { get { return _healthApptitude; } }

    /// <summary>
    /// The percentage that attack will increase upon a level up.
    /// </summary>
    public float AttackApptitude { get { return _attackApptitude; } }

    /// <summary>
    /// The percentage that defense will increase upon a level up.
    /// </summary>
    public float DefenseApptitude { get { return _defenseApptitude; } }

    /// <summary>
    /// The percentage that resistance will increase upon a level up.
    /// </summary>
    public float ResistanceApptitude { get { return _resistanceApptitude; } }

    /// <summary>
    /// The percentage that speed will increase upon a level up.
    /// </summary>
    public float SpeedApptitude { get { return _speedApptitude; } }

    /// <summary>
    /// The percentage that hit will increase upon a level up.
    /// </summary>
    public float HitApptitude { get { return _hitApptitude; } }
}
