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

    public override void Awake()
    {
        base.Awake();

        // Sets the target position to the squad's starting point.
        _targetPos = transform.position;
    }

    // Update is called once per frame
    public override void FixedUpdate()
    {
        // If the squad has a targeted position and its distance from it is greater than two...
        if (Vector3.Distance(transform.position, _targetPos) > 2)
        {
            // ...set the squad to move towards that position.
            Velocity = (_targetPos - transform.position).normalized * _speed;

            // Clamps the velocity of the squad on the y-axis.
            Velocity = new Vector3(Velocity.x, 0, Velocity.z);

            base.FixedUpdate();
        }
    }
}
