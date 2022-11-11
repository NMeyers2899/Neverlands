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

    [Tooltip("The squad this panel is looking at.")]
    private static SquadBehavior _squad;

    [Tooltip("The unit currently being looked at.")]
    private static UnitBehavior _unit;

    /// <summary>
    /// The squad this panel is looking at.
    /// </summary>
    public static SquadBehavior Squad { get { return _squad; } set { _squad = value; } }

    public static UnitBehavior Unit { get { return _unit; } set { _unit = value; } }

    /// <summary>
    /// Sets the view's unit to a given unit in the squad.
    /// </summary>
    /// <param name="position"> The position in the squad's array. </param>
    public static void SetUnit(int position)
    {
        _unit = _squad.Units[position];
    }

    private void ChangeUnitText()
    {
        // If there is no unit currently being looked at, the text boxes are empty.
        if (!_unit)
        {
            _unitStats[0].text = "";
            _unitStats[1].text = "";
            return;
        }

        _unitStats[0].text = "Name: " + _unit.UnitName + "\n" +
                           "\nLevel : " + _unit.Level + "\n" +
                           "\nRace/Class : " + _unit.UnitTypes + "\n" +
                           "\nHealth: " + (int)_unit.CurrentHealth + "/" + (int)_unit.MaxHealth + "\n" +
                           "\nAttack: " + (int)_unit.AttackPower + "\n" +
                           "\nDefense: " + (int)_unit.DefensePower + "\n" +
                           "\nResistance: " + (int)_unit.ResistancePower + "\n" +
                           "\nSpeed: " + (int)_unit.SpeedPower + "\n" +
                           "\nHit: " + (int)_unit.HitChance;

        _unitStats[1].text = "\nHealth: " + _unit.HealthApptitude + "%\n" +
                             "\nAttack: " + _unit.AttackApptitude + "%\n" +
                             "\nDefense: " + _unit.DefenseApptitude + "%\n" +
                             "\nResistance: " + _unit.ResistanceApptitude + "%\n" +
                             "\nSpeed: " + _unit.SpeedApptitude + "%\n" +
                             "\nHit: " + _unit.HitApptitude + "%";
    }

    private void Update()
    {
        if(!_squad)
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

        ChangeUnitText();
    }

}
