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

    void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive(); // Set the current enabled state of the label to the opposite of the current active state.
        }
    }

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

    void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);

        label.text = coordinates.x + "," + coordinates.y;
    }

    void UpdateName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
