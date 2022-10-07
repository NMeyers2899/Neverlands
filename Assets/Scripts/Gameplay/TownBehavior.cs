using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownBehavior : MonoBehaviour
{
    /// <summary>
    /// The tag that represents which faction currently controls the town (for inital map setup).
    /// </summary>
    public string FactionTag;

    /// <summary>
    /// The squads that are currently within the town.
    /// </summary>
    private List<GameObject> _nestedSquads;

    /// <summary>
    /// The squads that are currently within the town.
    /// </summary>
    public List<GameObject> NestedSquads { get { return _nestedSquads; } }

    private void Awake()
    {
        tag = FactionTag;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<SquadMovementBehavior>() && other.CompareTag(tag))
            _nestedSquads.Add(other.gameObject);
    }
}
