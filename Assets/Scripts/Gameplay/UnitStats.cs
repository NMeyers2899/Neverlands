using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit Type", menuName = "Unit/Create New Unit Type")]
public class UnitStats : ScriptableObject
{
    [SerializeField]
    [Tooltip("The maximum possible health of the unit.")]
    private float _maxHealth;

    [SerializeField]
    [Tooltip("The current health of the unit, capped at its max health.")]
    private float _currentHealth;

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
    [Tooltip("Influences the chance of a unit to get a critical hit.")]
    private float _critChance;

    [SerializeField]
    [Tooltip("Influences the chace of a unit to hit an opponent.")]
    private float _hitChance;
}
