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
    /// The object that will show which faction this town is affiliated with.
    /// </summary>
    public MeshRenderer  FactionIcon;

    /// <summary>
    /// The material given to the icons of a unit or town to denote their faction.
    /// </summary>
    public Material PlayerFactionMaterial, NeutralFactionMaterial, EnemyFactionMaterial;

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

        if (tag == "Player")
            FactionIcon.material = PlayerFactionMaterial;
        else if (tag == "Neutral")
            FactionIcon.material = NeutralFactionMaterial;
        else if (tag == "Enemy")
            FactionIcon.material = EnemyFactionMaterial;

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

        // Change the location and scale of the object.
        squad.transform.localScale /= 2;
        squad.transform.position = transform.position;
        squad.TargetPos = transform.position;

        // Disable the squad's collider while it is in the town.
        squad.GetComponentInChildren<Collider>().enabled = false;

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
                FactionIcon.material = PlayerFactionMaterial;
            else if (squad.tag == "Neutral")
                FactionIcon.material = NeutralFactionMaterial;
            else if (squad.tag == "Enemy")
                FactionIcon.material = EnemyFactionMaterial;

            // Change this town's tag based on the squad's tag.
            tag = squad.tag;

            // Add the squad to the town's list.
            OnAdd(squad);
        }
    }
}
