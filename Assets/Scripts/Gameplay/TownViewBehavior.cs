using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TownViewBehavior : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The buttons that appear on the panel that reference the squads in a given town.")]
    private Text[] _squadIcons = new Text[10];

    [SerializeField]
    [Tooltip("The text box that reveals the name of the town.")]
    private Text _townName;

    [SerializeField]
    [Tooltip("The town that the panel is currently viewing.")]
    private TownBehavior _town;

    /// <summary>
    /// The town that the panel is currently viewing.
    /// </summary>
    public TownBehavior Town { get { return _town; }  set { _town = value; } }

    /// <summary>
    /// Allows the user to select a squad from within a town's nested squads.
    /// </summary>
    /// <param name="index"> The position of the squad in the town's list. </param>
    public void SelectSquadFromTown(int index)
    {
        if (index > _town.NestedSquads.Count)
            return;

        GameManagerBehavior.Instance.SelectedSquad = _town.NestedSquads[index];
        _town.OnRemove(_town.NestedSquads[index]);
        GameManagerBehavior.Instance.SelectedTown = null;
    }

    private void Awake()
    {
        GameManagerBehavior.Instance.TownViewPanel = this;
    }

    private void Update()
    {
        if (!_town)
            return;

        _townName.text = _town.TownName;

        for(int i = 0; i < 10; i++)
        {
            if (i < _town.NestedSquads.Count)
                _squadIcons[i].text = _town.NestedSquads[i].CommanderUnit.UnitName;
            else
                _squadIcons[i].text = "";
        }
    }
}
