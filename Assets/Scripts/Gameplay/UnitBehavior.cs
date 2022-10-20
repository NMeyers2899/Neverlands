using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBehavior : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The stats for the given unit.")]
    private UnitStats _unitStats;

    [Tooltip("The current health of the unit. Once it reaches zero, the unit is considered dead.")]
    private float _currentHealth;
}
