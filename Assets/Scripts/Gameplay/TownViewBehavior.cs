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
    private static TownBehavior _town;

    /// <summary>
    /// The town that the panel is currently viewing.
    /// </summary>
    public static TownBehavior Town { get { return _town; }  set { _town = value; } }

    private void Update()
    {
        if (!_town)
            return;

        _townName.text = _town.TownName;

        for(int i = 0; i < _town.NestedSquads.Count; i++)
        {
            if (!_town.NestedSquads[i])
                _squadIcons[i].text = "";

            _squadIcons[i].text = _town.NestedSquads[i].GetComponent<SquadBehavior>().CommanderUnit.UnitName;
        }
    }
}
