using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit Type", menuName = "Unit/Create New Unit Type")]
public class UnitStats : ScriptableObject
{
    [SerializeField]
    [Tooltip("What the unit will be called.")]
    private string _unitName;

    [SerializeField]
    [Tooltip("The model for the unit.")]
    private GameObject _unitMesh;

    [SerializeField]
    [Tooltip("The type that determines the order of action in battle.")]
    private string _unitType;

    [SerializeField]
    [Tooltip("Determines whether or not the unit's attack is magic based or not. " +
        "(Determines whether or not the unit will use Defense or Resistance when reducing damage during an attack.)")]
    private bool _attackIsMagic;

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

    /// <summary>
    /// What the unit will be called.
    /// </summary>
    public string UnitName { get { return _unitName; } }

    /// <summary>
    /// The model for the unit.
    /// </summary>
    public GameObject UnitMesh { get { return _unitMesh;} }

    /// <summary>
    /// The type that determines the order of action in battle.
    /// </summary>
    public string UnitType { get { return _unitType; } }

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
    public float HitChange { get { return _hitChance; } }
}
