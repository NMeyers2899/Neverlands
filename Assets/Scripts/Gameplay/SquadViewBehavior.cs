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
    private SquadBehavior _squad;

    [Tooltip("The unit currently being looked at.")]
    private UnitBehavior _unit;

    /// <summary>
    /// The squad this panel is looking at.
    /// </summary>
    public SquadBehavior Squad { get { return _squad; } set { _squad = value; } }

    /// <summary>
    /// The unit currently being looked at.
    /// </summary>
    public UnitBehavior Unit { get { return _unit; } set { _unit = value; } }

    private void Awake()
    {
        GameManagerBehavior.Instance.SquadViewPanel = this;
    }

    /// <summary>
    /// Sets the view's unit to a given unit in the squad.
    /// </summary>
    /// <param name="position"> The position in the squad's array. </param>
    public void SetUnit(int position)
    {
        _squad.MovementBehavior.TargetPos = _squad.transform.position;
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
                           "\nHealth: " + (int)_unit.CurrentHealth + "/" + (int)_unit.UnitStats.MaxHealth + "\n" +
                           "\nAttack: " + (int)_unit.UnitStats.AttackPower + "\n" +
                           "\nMagic: " + (int)_unit.UnitStats.MagicPower + "\n" +
                           "\nDefense: " + (int)_unit.UnitStats.DefensePower + "\n" +
                           "\nResistance: " + (int)_unit.UnitStats.ResistancePower + "\n" +
                           "\nSkill: " + (int)_unit.UnitStats.SkillPower;

        _unitStats[1].text = "\nHealth: " + _unit.UnitStats.HealthApptitude + "%\n" +
                             "\nAttack: " + _unit.UnitStats.AttackApptitude + "%\n" +
                             "\nMagic: " + _unit.UnitStats.MagicApptitude + "%\n" +
                             "\nDefense: " + _unit.UnitStats.DefenseApptitude + "%\n" +
                             "\nResistance: " + _unit.UnitStats.ResistanceApptitude + "%\n" +
                             "\nSkill: " + _unit.UnitStats.SkillApptitude + "%";
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

            if(_squad.Units[i] == _squad.CommanderUnit)
            {
                _unitIcons[i].text = "*C* " + _squad.Units[i].UnitName;
                continue;
            }

            _unitIcons[i].text = _squad.Units[i].UnitName;
        }

        ChangeUnitText();
    }

}
