using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownBehavior : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The tag that represents which faction currently controls the town (for inital map setup).")]
    private string _factionTag;

    [SerializeField]
    [Tooltip("The object that will show which faction this town is affiliated with.")]
    private MeshRenderer _factionIcon;

    [SerializeField]
    [Tooltip("The material given to the icons of a unit or town to denote their faction.")]
    private Material PlayerFactionMaterial, NeutralFactionMaterial, EnemyFactionMaterial;

    [SerializeField]
    [Tooltip("The squads that are currently within the town.")]
    private List<GameObject> _nestedSquads;

    /// <summary>
    /// The squads that are currently within the town.
    /// </summary>
    public List<GameObject> NestedSquads { get { return _nestedSquads; } }

    private void Awake()
    {
        tag = _factionTag;

        if (tag == "Player")
            _factionIcon.material = PlayerFactionMaterial;
        else if (tag == "Neutral")
            _factionIcon.material = NeutralFactionMaterial;
        else if (tag == "Enemy")
            _factionIcon.material = EnemyFactionMaterial;

        _nestedSquads = new List<GameObject>();
    }

    /// <summary>
    /// Performs the logic for adding a squad to this town.
    /// </summary>
    /// <param name="squad"> The squad being added. </param>
    private void OnAdd(SquadMovementBehavior squad)
    {
        // Add the squad to this town's list.
        _nestedSquads.Add(squad.gameObject);

        // Change the location of the object, and disable it.
        squad.transform.position = transform.position;
        squad.TargetPos = transform.position;

        // Disable the squad's collider while it is in the town.
        squad.gameObject.SetActive(false);

        // Has the game manager deselect the squad as long as it is the one the player currently controls.
        if(GameManagerBehavior.SelectedSquad == squad)
            GameManagerBehavior.DeselectSquad();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Checks to see if the other object is a squad.
        SquadMovementBehavior squad = collision.gameObject.GetComponent<SquadMovementBehavior>();

        // If not, don't do anything.
        if (!squad)
            return;

        // If the squad shares a tag with this town, perform the logic for adding it to the town.
        if (squad.CompareTag(tag))
            OnAdd(squad);

        // If the squad is not a part of the same faction...
        else if (!squad.CompareTag(tag) && _nestedSquads.Count == 0)
        {
            // ...change the material of the icon depending on which faction is taking the town.
            if (squad.tag == "Player")
                _factionIcon.material = PlayerFactionMaterial;
            else if (squad.tag == "Neutral")
                _factionIcon.material = NeutralFactionMaterial;
            else if (squad.tag == "Enemy")
                _factionIcon.material = EnemyFactionMaterial;

            // Change this town's tag based on the squad's tag.
            tag = squad.tag;

            // Add the squad to the town's list.
            OnAdd(squad);
        }
    }
}
