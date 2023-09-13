using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isPlaceable = true;
    [SerializeField] TowerCash TowerCashScript;

    public bool GetIsPlaceable()
    {
        return isPlaceable;
    }

    void OnMouseDown()
    {
        if (isPlaceable)
        {
            bool isPlaced = TowerCashScript.PlaceTower(transform.position);
            isPlaceable = !isPlaced;
        }
    }
}
