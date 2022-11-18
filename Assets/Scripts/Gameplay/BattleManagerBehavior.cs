using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManagerBehavior : MonoBehaviour
{
    [Tooltip("The squads that will take part in the battle.")]
    private SquadBehavior _attackingSquad, _defendingSquad;

    /// <summary>
    /// The squad that initiated the battle.
    /// </summary>
    public SquadBehavior AttackingSquad { get { return _attackingSquad; } set { _attackingSquad = value; } }

    /// <summary>
    /// The squad the moves second during battle.
    /// </summary>
    public SquadBehavior DefendingSquad { get { return _defendingSquad; } set { _defendingSquad = value; } }
}
