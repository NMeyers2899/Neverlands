using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStats : ScriptableObject
{
    /// <summary>
    /// The total amount of health a unit can have.
    /// </summary>
    [SerializeField]
    private float _maxHealth;
    
    /// <summary>
    /// The current health of the unit.
    /// </summary>
    private float _currentHealth;
}
