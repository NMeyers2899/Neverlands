using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeBehavior : MonoBehaviour
{
    [Tooltip("The distance from this node to the start node.")]
    private int gCost;

    [Tooltip("The distance from this node to the end node.")]
    private int hCost;

    [Tooltip("The combined cost of the gCost and hCost.")]
    private int fCost;
}
