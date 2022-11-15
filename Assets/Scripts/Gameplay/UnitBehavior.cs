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
    [Tooltip("The stats for the given unit based off of their race.")]
    private RaceUnitStats _unitRaceStats;

    [SerializeField]
    [Tooltip("The stats for the given unit based off of their class.")]
    private ClassUnitStats _unitClassStats;

    [Tooltip("The unit's current health. Cannot go higher than its max. Once it hits zero, the unit is considered dead.")]
    private float _currentHealth;

    [Tooltip("The combined names of the unit's race and class.")]
    private string _unitTypes;

    [Tooltip("The stats and apptitudes of this unit.")]
    private UnitTypeData _unitStats;

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
    /// The stats and apptitudes of this unit.
    /// </summary>
    public UnitTypeData UnitStats { get { return _unitStats;} }

    /// <summary>
    /// Provides the formula for leveling up.
    /// </summary>
    private void OnLevelUp()
    {
        // Provides the formula for each individual stat to increase by.
        _unitStats.MaxHealth += ((_unitStats.MaxHealth / _level + 40) * ((_unitStats.HealthApptitude) / 100));
        if (_unitStats.MaxHealth > 9999999)
            _unitStats.MaxHealth = 9999999;
        
        _unitStats.AttackPower += ((_unitStats.AttackPower / _level + 10) * ((_unitStats.AttackApptitude) / 100));
        if (_unitStats.AttackPower > 999999)
            _unitStats.AttackPower = 999999;
        
        _unitStats.MagicPower += ((_unitStats.MagicPower / _level + 10) * ((_unitStats.MagicApptitude) / 100));
        if (_unitStats.MagicPower > 999999)
            _unitStats.MagicPower = 999999;

        _unitStats.DefensePower += ((_unitStats.DefensePower / _level + 10) * ((_unitStats.DefenseApptitude) / 100));
        if (_unitStats.DefensePower > 999999)
            _unitStats.DefensePower = 999999;

        _unitStats.ResistancePower += ((_unitStats.ResistancePower / _level + 10) * ((_unitStats.ResistanceApptitude) / 100));
        if (_unitStats.ResistancePower > 999999)
            _unitStats.ResistancePower = 999999;

        _unitStats.SkillPower += ((_unitStats.SkillPower / _level + 10) * ((_unitStats.SkillApptitude) / 100));
        if (_unitStats.SkillPower > 999999)
            _unitStats.SkillPower = 999999;
    }

    private void Awake()
    {
        // Setting up the unit's types.
        _unitTypes = _unitRaceStats.UnitTypeData.UnitTypeName + " / " + _unitClassStats.UnitTypeData.UnitTypeName;

        // Setting up the unit's base stats by combining the class and race stats.
        _unitStats.MaxHealth = _unitRaceStats.UnitTypeData.MaxHealth + _unitClassStats.UnitTypeData.MaxHealth;
        _unitStats.AttackPower = _unitRaceStats.UnitTypeData.AttackPower + _unitClassStats.UnitTypeData.AttackPower;
        _unitStats.MagicPower = _unitRaceStats.UnitTypeData.MagicPower + _unitClassStats.UnitTypeData.MagicPower;
        _unitStats.DefensePower = _unitRaceStats.UnitTypeData.DefensePower + _unitClassStats.UnitTypeData.DefensePower;
        _unitStats.ResistancePower = _unitRaceStats.UnitTypeData.ResistancePower + _unitClassStats.UnitTypeData.ResistancePower;
        _unitStats.SkillPower = _unitRaceStats.UnitTypeData.SkillPower + _unitClassStats.UnitTypeData.SkillPower;

        // Setting up the apptitudes for the unit by combining the class and race apptitudes.
        _unitStats.HealthApptitude = _unitRaceStats.UnitTypeData.HealthApptitude + _unitClassStats.UnitTypeData.HealthApptitude;
        _unitStats.AttackApptitude = _unitRaceStats.UnitTypeData.AttackApptitude + _unitClassStats.UnitTypeData.AttackApptitude;
        _unitStats.MagicApptitude = _unitRaceStats.UnitTypeData.MagicApptitude + _unitClassStats.UnitTypeData.MagicApptitude;
        _unitStats.DefenseApptitude = _unitRaceStats.UnitTypeData.DefenseApptitude + _unitClassStats.UnitTypeData.DefenseApptitude;
        _unitStats.ResistanceApptitude = _unitRaceStats.UnitTypeData.ResistanceApptitude + _unitClassStats.UnitTypeData.ResistanceApptitude;
        _unitStats.SkillApptitude = _unitRaceStats.UnitTypeData.SkillApptitude + _unitClassStats.UnitTypeData.SkillApptitude;

        // If the unit's level is higher than one, level up by the difference between their current level and one.
        for (int i = 1; i < _level; i++)
            OnLevelUp();

        // Sets the current health of the unit to whatever its max health is.
        _currentHealth = _unitStats.MaxHealth;

    }
}
