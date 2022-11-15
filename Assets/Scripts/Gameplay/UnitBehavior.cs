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

    [Tooltip("The unit's current health. Cannot go higher than its max. Once it hits zero, the unit is considered dead.")]
    private float _currentHealth;

    [Tooltip("The combined names of the unit's race and class.")]
    private string _unitTypes;

    [Tooltip("The base stats of a given unit type, which represent the following.\n" +
             "0 : The maximum health of the unit.\n" +
             "1 : The attack power of the unit.\n" +
             "2 : The magic power of the unit.\n" +
             "3 : The defense power of the unit. Meant to resist another unit's attack.\n" +
             "4 : The resistance power of the unit. Meant to resist another unit's magic.\n" +
             "5 : The skill of the unit, determining how often it can hit an attack, get critical hits, or dodge an attack.")]
    private float[] _unitStats = new float[6];

    [Tooltip("The following determines the rate at which each stat will grow for a unit during a level up (calculated as a percentage).\n" +
             "0 : The maximum health of the unit.\n" +
             "1 : The attack power of the unit.\n" +
             "2 : The magic power of the unit.\n" +
             "3 : The defense power of the unit. Meant to resist another unit's attack.\n" +
             "4 : The resistance power of the unit. Meant to resist another unit's magic.\n" +
             "5 : The skill of the unit, determining how often it can hit an attack, get critical hits, or dodge an attack.")]
    private float[] _unitStatApptitudes = new float[6];

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
    /// The stats of a given unit type, which represent the following. 
    /// 0 : The maximum health of the unit.
    /// 1 : The attack power of the unit.
    /// 2 : The magic power of the unit.
    /// 3 : The defense power of the unit. Meant to resist another unit's attack.
    /// 4 : The resistance power of the unit. Meant to resist another unit's magic.
    /// 5 : The skill of the unit, determining how often it can hit an attack, get critical hits, or dodge an attack.
    /// </summary>
    public float[] UnitStats { get { return _unitStats; } }

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

    /// <summary>
    /// Provides the formula for leveling up.
    /// </summary>
    private void OnLevelUp()
    {
        // For each stat, perform its level up calculation.
        for(int i = 0; i < _unitStats.Length; i++)
        {
            // If the stat is maximum health...
            if(i == 0)
            {
                // ...perform the calculation for increasing health.
                _unitStats[i] += ((_unitStats[i] / _level + 70) * ((_unitClassStats.UnitStatApptitudes[i] + _unitRaceStats.UnitStatApptitudes[i]) / 100));
                if (_unitStats[i] > 999999999)
                    _unitStats[i] = 999999999;
            }
            // If the stat is not maximum health...
            else
            {
                // ...perform the calculation for increasing the other stats.
                _unitStats[i] += ((_unitStats[i] / _level + 10) * ((_unitClassStats.UnitStatApptitudes[i] + _unitRaceStats.UnitStatApptitudes[i]) / 100));
                if (_unitStats[i] > 999999)
                    _unitStats[i] = 999999;
            }
        }
    }

    private void Awake()
    {
        // Setting up the unit's types.
        _unitTypes = _unitRaceStats.UnitTypeName + " / " + _unitClassStats.UnitTypeName;

        // Setting up the unit's base stats by combining the class and race stats.
        for (int i = 0; i < _unitStats.Length; i++)
            _unitStats[i] = _unitClassStats.UnitBaseStats[i] + _unitRaceStats.UnitBaseStats[i];

        // Setting up the apptitudes for the unit by combining the class and race apptitudes.
        for (int i = 0; i < _unitStatApptitudes.Length; i++)
            _unitStatApptitudes[i] = _unitClassStats.UnitStatApptitudes[i] + _unitRaceStats.UnitStatApptitudes[i];

        // If the unit's level is higher than one, level up by the difference between their current level and one.
        for (int i = 1; i < _level; i++)
            OnLevelUp();

        // Sets the current health of the unit to whatever its max health is.
        _currentHealth = _unitStats[0];

    }
}
