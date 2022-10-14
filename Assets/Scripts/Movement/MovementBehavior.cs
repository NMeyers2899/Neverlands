using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehavior : MonoBehaviour
{
    [Tooltip("The velocity of the object.")]
    private Vector3 _velocity;

    [Tooltip("The rigid body of the object this is attached to.")]
    private Rigidbody _rigidbody;

    public Vector3 Velocity { get { return _velocity; } set { _velocity = value; } }

    public virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public virtual void FixedUpdate()
    {
        _rigidbody.velocity = _velocity;
    }
}
