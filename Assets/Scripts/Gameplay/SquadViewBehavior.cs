using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SquadViewBehavior : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The buttons that appear on the panel that reference the units in a given squad.")]
    private Text[] _unitIcons = new Text[9];

    [SerializeField]
    [Tooltip("The text boxes that reference a given unit's stats.")]
    private Text[] _unitStats = new Text[2];

    [SerializeField]
    [Tooltip("The squad this panel is looking at.")]
    private SquadBehavior _squad;

    [SerializeField]
    [Tooltip("The unit currently being looked at.")]
    private UnitBehavior _unit;

    /// <summary>
    /// The squad this panel is looking at.
    /// </summary>
    public SquadBehavior Squad { get { return _squad; } set { _squad = value; } }

    private void Update()
    {
        if(_squad)
        {
            return;
        }

        for (int i = 0; i < _unitIcons.Length; i++)
        {
            if (!_squad.Units[i])
            {
                _unitIcons[i].text = "";
                continue;
            }

            _unitIcons[i].text = _squad.Units[i].UnitName;
        }
            

        // If there is no unit currently being looked at, the text boxes are empty.
        if (!_unit)
        {
            _unitStats[0].text = "";
            _unitStats[1].text = "";
            return;
        }

        _unitStats[0].text = "Name: " + _unit.UnitName + "\n" +
                           "\nHealth: " + _unit.CurrentHealth + "/" + _unit.MaxHealth + "\n" +
                           "\nAttack: " + _unit.AttackPower + "\n" +
                           "\nDefense: " + _unit.DefensePower + "\n" +
                           "\nResistance: " + _unit.ResistancePower + "\n" +
                           "\nSpeed: " + _unit.SpeedPower + "\n" +
                           "\nHit: " + _unit.HitChance;

        _unitStats[1].text = "\nHealth: " + _unit.HealthApptitude + "%\n" +
                             "\nAttack: " + _unit.AttackApptitude + "%\n" +
                             "\nDefense: " + _unit.DefenseApptitude + "%\n" +
                             "\nResistance: " + _unit.ResistanceApptitude + "%\n" +
                             "\nSpeed: " + _unit.SpeedApptitude + "%\n" +
                             "\nHit: " + _unit.HitApptitude + "%";
    }

}
