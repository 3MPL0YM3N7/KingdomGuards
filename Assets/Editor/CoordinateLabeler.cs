using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    TextMeshPro labelTextfield;
    Vector2Int coordinates = new Vector2Int();

    void Awake()
    {
        labelTextfield = GetComponent<TextMeshPro>();
        labelTextfield.enabled = false;

        DisplayCoordinates();
    }

    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
            labelTextfield.enabled = false; 
        }

        SetColorCoordinates();
        ToggleLabels();
    }

    void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);

        labelTextfield.text = $"{coordinates.x}, {coordinates.y}";
    }

    void UpdateObjectName()
    {
        transform.parent.name = labelTextfield.text;
    }

    void SetColorCoordinates()
    {
        if (GetComponentInParent<Waypoint>().GetIsPlaceable())
        {
            labelTextfield.color = Color.white;
        }
        else
        {
            labelTextfield.color = Color.black;
        }
    }

    void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            labelTextfield.enabled = !labelTextfield.enabled;
        }
    }
}
