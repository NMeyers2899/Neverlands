using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBehavior : MonoBehaviour
{
    [Tooltip("The name of the unit.")]
    private string _unitName;

    [Tooltip("The type that determines the order of action in battle.")]
    private string _unitType;

    [Tooltip("The stats for the given unit.")]
    private UnitStats _unitClassStats, _unitRaceStats;

    [Tooltip("The current health of the unit. Once it reaches zero, the unit is considered dead.")]
    private float _currentHealth;

    [Tooltip("The maximum possible health of the unit.")]
    private float _maxHealth;

    [Tooltip("How much damage the unit will deal.")]
    private float _attackPower;

    [Tooltip("How resistant the unit is to physical damage.")]
    private float _defensePower;

    [Tooltip("How resistant the unit is to magic damage.")]
    private float _resistancePower;

    [Tooltip("How well the unit is able to dodge incoming attacks.")]
    private float _speedPower;

    [Tooltip("Influences the chance of a unit to hit an opponent.")]
    private float _hitChance;

    [Tooltip("The percentage that stats will increase by on a level up.")]
    private float _healthApptitude, _attackApptitude, _defenseApptitude, _resistanceApptitude, _speedApptitude, _hitApptitude;

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

    private void Awake()
    {
        // Setting up the unit's base stats by combining the class and race stats.
        _maxHealth = _unitClassStats.MaxHealth + _unitRaceStats.MaxHealth;
        _attackPower = _unitClassStats.AttackPower + _unitRaceStats.AttackPower;
        _defensePower = _unitClassStats.DefensePower + _unitRaceStats.DefensePower;
        _resistancePower = _unitClassStats.ResistancePower + _unitRaceStats.ResistancePower;
        _speedPower = _unitClassStats.ResistancePower + _unitRaceStats.SpeedPower;
        _hitChance = _unitClassStats.HitChance + _unitRaceStats.HitChance;

        // Setting up the apptitudes for the unit by combining the class and race apptitudes.
        _healthApptitude = _unitClassStats.HealthApptitude + _unitRaceStats.HealthApptitude;
        _attackApptitude = _unitClassStats.AttackApptitude + _unitRaceStats.AttackApptitude;
        _defenseApptitude = _unitClassStats.DefenseApptitude + _unitRaceStats.DefenseApptitude;
        _resistanceApptitude = _unitClassStats.ResistanceApptitude + _unitRaceStats.ResistanceApptitude;
        _speedApptitude = _unitClassStats.SpeedApptitude + _unitRaceStats.SpeedApptitude;
        _hitApptitude = _unitClassStats.HitApptitude + _unitRaceStats.HitApptitude;
    }
}
