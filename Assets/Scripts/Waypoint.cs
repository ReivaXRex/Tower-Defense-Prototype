using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; } }   

    void OnMouseDown()
    {
        if (isPlaceable)
        {
            // If a Tower has been placed return true, if unable to place a Tower return false.
            bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);

            isPlaceable = !isPlaced;
   
        }
  
    }

    
}
