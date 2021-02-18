using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    
    [Space]
    [SerializeField] [Range(0f, 5f)] float speed = 1f;

    private void Start()
    {
        StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath()
    {
        foreach (Waypoint waypoint in path)
        {

            // Set-up Start and End positions.
            Vector3 startPos = transform.position;
            Vector3 endPos = waypoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPos); // Face towards the end position to correct rotation.

            while (travelPercent < 1f) // while less than one, the end position.
            {
                travelPercent += Time.deltaTime * speed; // Update the travel percent
                transform.position = Vector3.Lerp(startPos, endPos, travelPercent); // Move the enemy
                yield return new WaitForEndOfFrame(); 
            }
        }   
    }
}


