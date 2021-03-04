using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class Coordinates : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.black;
    [SerializeField] Color blockedColor = Color.white;

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    Waypoint waypoint;

    private void Awake()
    {
        waypoint = GetComponentInParent<Waypoint>();
       
        label = GetComponent<TextMeshPro>();
        label.enabled = false;

        DisplayCoordinates();
    }

    void Update()
    {
        if (!Application.isPlaying) // Only Execute in Edit Mode
        {
            DisplayCoordinates();
            UpdateName();
        }

        ColorCoordinates(waypoint.IsPlaceable); 
        ToggleLabels();
    }

    /// <summary>
    /// Toggle the display of the Coordinates on the tiles.
    /// </summary>
    void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive(); // Set the current enabled state of the label to the opposite of the current active state.
        }
    }

    /// <summary>
    /// Color the coordinates by whether or not a Tower can be placed upon a tile.
    /// </summary>
    /// <param name="isPlaceable">
    /// White if blocked (false), black if free (true).
    /// </param>
    void ColorCoordinates(bool isPlaceable)
    {
        if (!isPlaceable)
        {
            label.color = blockedColor;
        }
        else
        {
            label.color = defaultColor;
        }
    }

    /// <summary>
    /// Display the tile's coordinates on it's surface.
    /// </summary>
    void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / 10);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / 10);

        label.text = coordinates.x + "," + coordinates.y;
    }

    /// <summary>
    /// Update the name of the gameObject to it's coordinates.
    /// </summary>
    void UpdateName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
