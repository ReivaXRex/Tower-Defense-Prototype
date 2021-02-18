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
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    void FindPath()
    {
        path.Clear(); // Clear path List for a new path List.
        
        GameObject parent = GameObject.FindGameObjectWithTag("Path"); // Find the gameObject tagged with 'Path; & store it within a variable.

        foreach (Transform child in parent.transform) // Loop through the children of that object
        {
            Waypoint waypoint = child.GetComponent<Waypoint>();

            if (waypoint != null)
            {
                path.Add(waypoint); // Find the Waypoint component within the child objects and add them to the path List.
            }
       
        }
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
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

        Destroy(gameObject);
    }
}


