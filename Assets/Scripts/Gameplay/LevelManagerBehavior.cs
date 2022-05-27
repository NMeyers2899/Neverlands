using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerBehavior : MonoBehaviour
{
    /// <summary>
    /// The nodes in the grid that make up the current level.
    /// </summary>
    [SerializeField]
    private GameObject _nodePrefab;

    /// <summary>
    /// The nodes that make up the current level.
    /// </summary>
    [SerializeField]
    private List<NodeBehavior> _nodes = new List<NodeBehavior>();

    // The columns of rows of the grid.
    [SerializeField]
    private int _columns;
    [SerializeField]
    private int _rows;

    /// <summary>
    /// The scale of the map.
    /// </summary>
    private int _scale = 1;

    /// <summary>
    /// The origin of the map. Where the first node is spawned.
    /// </summary>
    private Vector3 _mapOrigin = new Vector3(0, 0, 0);

    private void Awake()
    {
        if (_nodePrefab)
            GenerateMap();
        else
            Debug.Log("Missing Map");
    }

    /// <summary>
    /// Generates a map using the prefab given for the nodes in the graph.
    /// </summary>
    private void GenerateMap()
    {
        // Sets up a new game object for the future node.
        GameObject node;

        // For each of the given columns and rows, a new node is generated based on the prefab given. That node is then added into the list of nodes.
        for(int i = 0; i < _columns; i++)
        {
            for (int j = 0; j < _rows; j++)
            {
                node = Instantiate(_nodePrefab, new Vector3(_mapOrigin.x + _scale * i, _mapOrigin.y + _scale, _mapOrigin.z + _scale * j), Quaternion.identity);
                node.GetComponent<NodeBehavior>().XPos = i;
                node.GetComponent<NodeBehavior>().YPos = j;
                _nodes.Add(node.GetComponent<NodeBehavior>());
            }
        }
    }
}
