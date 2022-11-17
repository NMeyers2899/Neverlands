using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerBehavior : MonoBehaviour
{
    [Tooltip("The squad that the player has currently selected.")]
    private SquadBehavior _selectedSquad;

    [Tooltip("The town that the player has currently selected.")]
    private TownBehavior _selectedTown;

    [Tooltip("The object that will be hit with a ray.")]
    private RaycastHit _hit;

    [Tooltip("The current position of the mouse when the user clicks either button.")]
    private Vector3 _mousePosition;

    [Tooltip("An instance of the GameManagerBehavior, makes an object with this behavior attached if there is not one currently.")]
    private static GameManagerBehavior _instance;

    /// <summary>
    /// An instance of the GameManagerBehavior, makes an object with this behavior attached if there is not one currently.
    /// </summary>
    public static GameManagerBehavior Instance
    {
        get 
        {
            if(!_instance)
            {
                _instance = FindObjectOfType<GameManagerBehavior>();
            }
            if(!_instance)
            {
                GameObject gameManager = new GameObject("GameManager");
                _instance = gameManager.AddComponent<GameManagerBehavior>();
            }

            return _instance;
        }
    }

    /// <summary>
    /// The squad that the player has currently selected.
    /// </summary>
    public SquadBehavior SelectedSquad { get { return _selectedSquad; } set { _selectedSquad = value; } }

    /// <summary>
    /// The town that the player has currently selected.
    /// </summary>
    public TownBehavior SelectedTown { get { return _selectedTown; } set { _selectedTown = value; } }

    public SquadViewBehavior SquadViewPanel { get { return SquadViewBehavior.Instance; } }
    public TownViewBehavior TownViewPanel { get { return TownViewBehavior.Instance; } }

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
            SquadViewPanel.gameObject.SetActive(true);
            SquadViewPanel.Unit = null;
            SquadViewPanel.Squad = selectedObject.GetComponent<SquadBehavior>();

            return;
        }

        if(selectedObject.GetComponent<TownBehavior>())
        {
            // Set the selected town to the given town.
            _selectedTown = selectedObject.GetComponent<TownBehavior>();

            _selectedSquad = null;
            TownViewPanel.gameObject.SetActive(true);
            TownViewPanel.Town = _selectedTown;
        }
    }

    /// <summary>
    /// Handles the logic that occurs when a unit is deselected.
    /// </summary>
    public void DeselectObject()
    {
        _selectedSquad = null;
        _selectedTown = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(!_selectedSquad)
            SquadViewPanel.gameObject.SetActive(false);

        if (!_selectedTown)
            TownViewPanel.gameObject.SetActive(false);

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
            else if(_selectedSquad && _selectedSquad.CompareTag("Player"))
                // ...set that squad's target to the hit point.
                _selectedSquad.MovementBehavior.TargetPos = _hit.point;  
        }
        
        // If the player right clicks, deselect the current unit.
        if (Input.GetMouseButtonDown(1))
            DeselectObject();
    }
}
