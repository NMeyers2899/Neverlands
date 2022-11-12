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
    [Tooltip("The name of the given town.")]
    private Text _townName;

    [SerializeField]
    [Tooltip("The town that the panel is currently viewing.")]
    private static TownBehavior _town;

    private void Update()
    {
        if (!_town)
            return;

        _townName.text = _town.TownName;

        for(int i = 0; i < _town.NestedSquads.Count; i++)
        {
            _squadIcons[i].text = _town.NestedSquads[i].GetComponent<SquadBehavior>().CommanderUnit.UnitName;
        }
    }
}
