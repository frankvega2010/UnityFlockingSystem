using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointForce : SteeringBehaviour
{
    public GameObject waypointsParent;
    public GameObject[] waypoints;
    public float waypointDistance;
    public int waypointIndex;
    public bool isGlobalWaypointEnabled;
    //public bool enableWaypoints;

    // Start is called before the first frame update
    void Start()
    {
        waypoints = new GameObject[waypointsParent.transform.childCount];

        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = waypointsParent.transform.GetChild(i).gameObject;
        }

        waypointIndex = 0;
    }

    public override Vector3 GetSteer(List<Boid> boids, List<GameObject> foods, Boid currentBoid)
    {
        if(waypoints.Length > 0)
        {
            Vector3 waypointForce = Vector3.zero;

            if(!currentBoid.isThreat)
            {
                if (isGlobalWaypointEnabled)
                {
                    Vector3 desiredPosition = waypoints[waypointIndex].transform.position - currentBoid.transform.position;

                    Vector3 distance = (desiredPosition.normalized * currentBoid.speed) - currentBoid.velocity;

                    if (Vector3.Distance(currentBoid.transform.position, waypoints[waypointIndex].transform.position) < waypointDistance)
                    {
                        waypointIndex++;
                        if (waypointIndex >= waypoints.Length)
                        {
                            waypointIndex = 0;
                        }
                    }

                    waypointForce = distance;
                }
                else
                {
                    Vector3 desiredPosition = waypoints[currentBoid.waypointIndex].transform.position - currentBoid.transform.position;

                    Vector3 distance = (desiredPosition.normalized * currentBoid.speed) - currentBoid.velocity;

                    if (Vector3.Distance(currentBoid.transform.position, waypoints[currentBoid.waypointIndex].transform.position) < waypointDistance)
                    {
                        currentBoid.waypointIndex++;
                        if (currentBoid.waypointIndex >= waypoints.Length)
                        {
                            currentBoid.waypointIndex = 0;
                        }
                    }

                    waypointForce = distance;
                }
            }

            return waypointForce;
        }
        else
        {
            return Vector3.zero;
        }
    }
}
