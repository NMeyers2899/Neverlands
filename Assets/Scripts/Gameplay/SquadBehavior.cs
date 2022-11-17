using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquadBehavior : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The list of units within this squad.")]
    private UnitBehavior[] _units = new UnitBehavior[9];

    [SerializeField]
    [Tooltip("The commanding unit of the squad. If they die in battle, the squad is defeated.")]
    private UnitBehavior _commanderUnit;

    [Tooltip("The squad's movement behavior.")]
    private SquadMovementBehavior _movementBehavior;

    /// <summary>
    /// The list of units within this squad.
    /// </summary>
    public UnitBehavior[] Units { get { return _units; } }

    /// <summary>
    /// The commanding unit of the squad. If they die in battle, the squad is defeated.
    /// </summary>
    public UnitBehavior CommanderUnit { get { return _commanderUnit; } }

    /// <summary>
    /// The squad's movement behavior.
    /// </summary>
    public SquadMovementBehavior MovementBehavior { get { return _movementBehavior; } }

    private void Awake()
    {
        _movementBehavior = GetComponent<SquadMovementBehavior>();
    }

    private void Update()
    {
        if (!_commanderUnit || _commanderUnit.CurrentHealth <= 0)
            Destroy(gameObject);
    }
}
