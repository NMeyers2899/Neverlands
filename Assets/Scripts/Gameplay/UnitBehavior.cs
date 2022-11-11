using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBehavior : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The name of the unit.")]
    private string _unitName;

    [SerializeField]
    [Tooltip("The unit's current level.")]
    [Range(1, 9999)]
    private int _level = 1;

    [SerializeField]
    [Tooltip("The stats for the given unit.")]
    private UnitStats _unitClassStats, _unitRaceStats;

    [Tooltip("The combined names of the unit's race and class.")]
    private string _unitTypes;

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
    /// The name of the unit.
    /// </summary>
    public string UnitName { get { return _unitName; } }

    /// <summary>
    /// The unit's current level.
    /// </summary>
    public int Level { get { return _level; } }

    /// <summary>
    /// The combined names of the unit's race and class.
    /// </summary>
    public string UnitTypes { get { return _unitTypes; } }

    /// <summary>
    /// The current health of the unit. Once it reaches zero, the unit is considered dead.
    /// </summary>
    public float CurrentHealth { get { return _currentHealth; } }

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

    private void OnLevelUp()
    {
        _maxHealth += ((_maxHealth / _level + 70) * ((_unitClassStats.HealthApptitude + _unitRaceStats.HealthApptitude) / 100));
        if (_maxHealth > 99999999)
            _maxHealth = 99999999;

        _attackPower += ((_attackPower / _level + 10) * ((_unitClassStats.AttackApptitude + _unitRaceStats.AttackApptitude) / 100));
        if (_attackPower > 999999)
            _attackPower = 999999;

        _defensePower += ((_defensePower / _level + 10) * ((_unitClassStats.DefenseApptitude + _unitRaceStats.DefenseApptitude) / 100));
        if (_defensePower > 999999)
            _defensePower = 999999;

        _resistancePower += ((_resistancePower / _level + 10) * ((_unitClassStats.ResistanceApptitude + _unitRaceStats.ResistanceApptitude) / 100));
        if (_resistancePower > 999999)
            _resistancePower = 999999;

        _speedPower += ((_speedPower / _level + 10) * ((_unitClassStats.SpeedApptitude + _unitRaceStats.SpeedApptitude) / 100));
        if (_speedPower > 999999)
            _speedPower = 999999;

        _hitChance += ((_hitChance / _level + 10) * ((_unitClassStats.HitApptitude + _unitRaceStats.HitApptitude) / 100));
        if (_hitChance > 999999)
            _hitChance = 999999;
    }

    private void Awake()
    {
        // Setting up the unit's types.
        _unitTypes = _unitRaceStats.UnitTypeName + " / " + _unitClassStats.UnitTypeName;

        // Setting up the unit's base stats by combining the class and race stats.
        _maxHealth = _unitClassStats.MaxHealth + _unitRaceStats.MaxHealth;
        _currentHealth = _maxHealth;
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

        for (int i = 1; i < _level; i++)
            OnLevelUp();
    }
}
