using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerBehavior : MonoBehaviour
{
    [Tooltip("The squad that the player has currently selected.")]
    private static SquadMovementBehavior _selectedSquad;

    [Tooltip("The object that will be hit with a ray.")]
    private RaycastHit _hit;

    [Tooltip("The current position of the mouse when the user clicks either button.")]
    private Vector3 _mousePosition;

    [SerializeField]
    [Tooltip("The panel that will display a squad, town, or unit's stats.")]
    private SquadViewBehavior _squadViewPanel;

    /// <summary>
    /// Handles the logic that occurs when a unit is selected.
    /// </summary>
    /// <param name="selectedSquad"> The squad that has been selected by the player. </param>
    public void SelectSquad(Transform selectedSquad)
    {
        // If the object was not a squad...
        if (!selectedSquad.GetComponent<SquadMovementBehavior>())
            // ...return.
            return;

        // Make the current selected squad that squad.
        _selectedSquad = selectedSquad.GetComponent<SquadMovementBehavior>();

        // Set the view panel's squad to the given squad.
        _squadViewPanel.gameObject.SetActive(true);
        SquadViewBehavior.Unit = null;
        SquadViewBehavior.Squad = selectedSquad.GetComponent<SquadBehavior>();
       
    }

    /// <summary>
    /// The squad that the player has currently selected.
    /// </summary>
    public static SquadMovementBehavior SelectedSquad { get { return _selectedSquad; } }

    /// <summary>
    /// Handles the logic that occurs when a unit is deselected.
    /// </summary>
    public static void DeselectSquad()
    {
        _selectedSquad = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(!_selectedSquad)
            _squadViewPanel.gameObject.SetActive(false);

        // If the player left clicks...
        if (Input.GetMouseButtonDown(0))
        {
            // ...update the current mouse position, and...
            _mousePosition = Input.mousePosition;
            // ...create a ray to check if something gets hit.
            Ray ray = Camera.main.ScreenPointToRay(_mousePosition);

            // Check if something was hit, if it was and you have no squad selected...
            if (Physics.Raycast(ray, out _hit) && _selectedSquad == null)
            {
                // ...run the SelectSquad function, giving it the transform of what was hit.
                SelectSquad(_hit.transform);
            }
            // If the player has a selected squad...
            else if(_selectedSquad.CompareTag("Player"))
                // ...set that squad's target to the hit point.
                _selectedSquad.TargetPos = _hit.point;
        }
        
        // If the player right clicks, deselect the current unit.
        if (Input.GetMouseButtonDown(1))
            DeselectSquad();
    }
}
