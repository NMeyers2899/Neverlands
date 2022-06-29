using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementBehavior : MonoBehaviour
{
    /// <summary>
    /// How fast the camera will be able to move.
    /// </summary>
    [SerializeField]
    private float _panSpeed;

    /// <summary>
    /// How far the mouse needs to be away from the border to make the camera move in that direction.
    /// </summary>
    [SerializeField]
    private float _panBorderDistance;

    /// <summary>
    /// How far the camera will be able to move.
    /// </summary>
    [SerializeField]
    private Vector2 _panLimit;

    /// <summary>
    /// Changes how fast the camera will zoom in or out when using the scroll wheel.
    /// </summary>
    [SerializeField]
    private float _scrollSpeed;

    /// <summary>
    /// How far the mouse can scroll around.
    /// </summary>
    [SerializeField]
    private float _scrollLimit;
    
    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = transform.position;

        // Gets input from the user based on their mouse position or the keys they input.
        if (Input.GetKey(KeyCode.W) || Input.mousePosition.y >= Screen.height - _panBorderDistance)
            currentPosition.z += _panSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <= _panBorderDistance)
            currentPosition.z -= _panSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - _panBorderDistance)
            currentPosition.x += _panSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.A) || Input.mousePosition.x <= _panBorderDistance)
            currentPosition.x -= _panSpeed * Time.deltaTime;

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        currentPosition.y -= scroll * _scrollSpeed * Time.deltaTime;

        // Clamps the position to a given area.
        currentPosition.x = Mathf.Clamp(currentPosition.x, -_panLimit.x, _panLimit.x);
        currentPosition.z = Mathf.Clamp(currentPosition.z, -_panLimit.y, _panLimit.y);
        currentPosition.y = Mathf.Clamp(currentPosition.y, 10, 25);


        transform.position = currentPosition;
    }
}
