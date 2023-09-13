using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    public float enemySpeed = 1f;

    void OnEnable()
    {
        FindPath();
        GoToStart();
        StartCoroutine(FollowPath());
    }

    void FindPath()
    {
        path.Clear();

        GameObject taggedPathParent = GameObject.FindGameObjectWithTag("Path");

        foreach (Transform pathChild in taggedPathParent.transform)
        {
            Waypoint waypoint = pathChild.GetComponent<Waypoint>();
            if (waypoint != null)
            {
                path.Add(waypoint);
            }
        }
    }

    void GoToStart()
    {
        transform.position = path[0].transform.position;
    }

    IEnumerator FollowPath()
    {
        foreach (Waypoint waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;

            // face the moving direction
            transform.LookAt(endPosition);

            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * enemySpeed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
        // enemy didn't die
        gameObject.SetActive(false);
        FindObjectOfType<PlayerHealth>().DecreasePlayerHealth();
    }
}
