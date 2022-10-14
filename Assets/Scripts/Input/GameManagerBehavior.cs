using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerBehavior : MonoBehaviour
{
    [Tooltip("The squad that the player has currently selected.")]
    private static SquadMovementBehavior _selectedSquad;

    [Tooltip("The object that will be hit with a ray.")]
    private RaycastHit _hit;

    [Tooltip("The current position of the mouse when the user clicks either button.")]
    private Vector3 _mousePosition;

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

        // If the squad is a player squad...
        if (selectedSquad.CompareTag("Player"))
            // ...make the current selected squad that squad.
            _selectedSquad = selectedSquad.GetComponent<SquadMovementBehavior>();
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
        // If the player left clicks...
        if (Input.GetMouseButtonDown(0))
        {
            // ...update the current mouse position, and...
            _mousePosition = Input.mousePosition;
            // ...create a ray to check if something gets hit.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Check if something was hit, if it was and you have no squad selected...
            if (Physics.Raycast(ray, out _hit) && _selectedSquad == null)
            {
                // ...run the SelectSquad function, giving it the transform of what was hit.
                SelectSquad(_hit.transform);
            }
            // If the player has a selected squad...
            else
                // ...set that squad's target to the hit point.
                _selectedSquad.TargetPos = _hit.point;
        }
        
        // If the player right clicks, deselect the current unit.
        if (Input.GetMouseButtonDown(1))
            DeselectSquad();
    }
}
