using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquadMovementBehavior : MovementBehavior
{
    /// <summary>
    /// The position that the squad will move towards.
    /// </summary>
    private Vector3 _targetPos;

    /// <summary>
    /// The speed at which the unit moves on the map.
    /// </summary>
    [SerializeField]
    private float _speed;

    /// <summary>
    /// The position that the squad will move towards.
    /// </summary>
    public Vector3 TargetPos { get { return _targetPos; } set { _targetPos = value; } }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, _targetPos) > 2)
        {
            Velocity = (transform.position - _targetPos).normalized * _speed;
        }
    }
}
