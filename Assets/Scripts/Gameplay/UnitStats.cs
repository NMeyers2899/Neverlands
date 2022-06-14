using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStats : ScriptableObject
{
    /// <summary>
    /// The maximum possible health of the unit.
    /// </summary>
    [SerializeField]
    private float _maxHealth;

    /// <summary>
    /// The current health of the unit, capped at its max health.
    /// </summary>
    [SerializeField]
    private float _currentHealth;

    /// <summary>
    /// How much damage the unit will deal.
    /// </summary>
    [SerializeField]
    private float _attackPower;

    /// <summary>
    /// How resistant the unit is to physical damage.
    /// </summary>
    [SerializeField]
    private float _defensePower;

    /// <summary>
    /// How resistant the unit is to magic damage.
    /// </summary>
    [SerializeField]
    private float _resistancePower;

    /// <summary>
    /// How quickly the unit will be able to move and attack during combat.
    /// </summary>
    [SerializeField]
    private float _speedPower;

    /// <summary>
    /// Influences the chance of a unit to get a critical hit.
    /// </summary>
    [SerializeField]
    private float _critChance;

    /// <summary>
    /// Influences the chace of a unit to hit an opponent.
    /// </summary>
    [SerializeField]
    private float _hitChance;
}
