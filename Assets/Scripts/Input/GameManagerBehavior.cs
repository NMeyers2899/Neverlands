using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerBehavior : MonoBehaviour
{
    [Tooltip("The squad that the player has currently selected.")]
    private static SquadMovementBehavior _selectedSquad;

    [Tooltip("The town that the player has currently selected.")]
    private static TownBehavior _selectedTown;

    [Tooltip("The object that will be hit with a ray.")]
    private RaycastHit _hit;

    [Tooltip("The current position of the mouse when the user clicks either button.")]
    private Vector3 _mousePosition;

    [SerializeField]
    [Tooltip("The panel that will display a squad or unit's stats.")]
    private SquadViewBehavior _squadViewPanel;

    [SerializeField]
    [Tooltip("The panel that will display a town's stats and the squads within.")]
    private TownViewBehavior _townViewPanel;

    /// <summary>
    /// Handles the logic that occurs when n object is selected.
    /// </summary>
    /// <param name="selectedObject"> The object that has been selected by the player. </param>
    public void PlayerSelect(Transform selectedObject)
    {
        // If the object is a squad...
        if (selectedObject.TryGetComponent(out _selectedSquad))
        {
            // Make sure that the town panel is set false.
            _selectedTown = null;
            // Set the view panel's squad to the given squad.
            _squadViewPanel.gameObject.SetActive(true);
            SquadViewBehavior.Unit = null;
            SquadViewBehavior.Squad = selectedObject.GetComponent<SquadBehavior>();

            return;
        }

        if(selectedObject.GetComponent<TownBehavior>())
        {
            // Set the selected town to the given town.
            _selectedTown = selectedObject.GetComponent<TownBehavior>();

            _selectedSquad = null;
            _townViewPanel.gameObject.SetActive(true);
            TownViewBehavior.Town = _selectedTown;
        }
    }

    /// <summary>
    /// The squad that the player has currently selected.
    /// </summary>
    public static SquadMovementBehavior SelectedSquad { get { return _selectedSquad; } }

    /// <summary>
    /// Handles the logic that occurs when a unit is deselected.
    /// </summary>
    public static void DeselectObject()
    {
        _selectedSquad = null;
        _selectedTown = null;
    }

    /// <summary>
    /// Allows the user to select a squad in a given position from a town.
    /// </summary>
    public static void SelectSquadFromTown(int position)
    {
        _selectedSquad = _selectedTown.NestedSquads[position].GetComponent<SquadMovementBehavior>();
        _selectedTown = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(!_selectedSquad)
            _squadViewPanel.gameObject.SetActive(false);

        if (!_selectedTown)
            _townViewPanel.gameObject.SetActive(false);

        // If the player left clicks...
        if (Input.GetMouseButtonDown(0))
        {
            // ...update the current mouse position, and...
            _mousePosition = Input.mousePosition;
            // ...create a ray to check if something gets hit.
            Ray ray = Camera.main.ScreenPointToRay(_mousePosition);

            // Check if something was hit, if it was and you have no squad selected...
            if (Physics.Raycast(ray, out _hit) && !_selectedSquad && !_selectedTown)
            {
                // ...run the SelectSquad function, giving it the transform of what was hit.
                PlayerSelect(_hit.transform);
                return;
            }

            // If the player has a selected squad...
            else if(_selectedSquad.CompareTag("Player"))
                // ...set that squad's target to the hit point.
                _selectedSquad.TargetPos = _hit.point;  
        }
        
        // If the player right clicks, deselect the current unit.
        if (Input.GetMouseButtonDown(1))
            DeselectObject();
    }
}
