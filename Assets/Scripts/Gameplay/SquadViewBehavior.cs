using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SquadViewBehavior : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The buttons that appear on the panel that reference the units in a given squad.")]
    private Button[] _unitIcons = new Button[9];

    [SerializeField]
    [Tooltip("The text boxes that reference a given unit's stats.")]
    private Text[] _unitStats = new Text[2];

    [SerializeField]
    [Tooltip("The unit currently being looked at.")]
    private UnitBehavior _unit;

    [SerializeField]
    [Tooltip("The squad that the view panel is currently looking at.")]
    private SquadBehavior _selectedSquad;

    /// <summary>
    /// The squad that the view panel is currently looking at.
    /// </summary>
    public SquadBehavior SelectedSquad { get { return _selectedSquad; } 
                                         set { _selectedSquad = value; } }

    private void Update()
    {
        if (!_unit)
            return;

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
