using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteerManager : MonoBehaviour
{
    public GameObject steerBehavioursParent;
    public FoodSpawner foodSpawner;
    public SteeringBehaviour[] steerBehaviours;

    private Vector3[] behavioursVector;

    // Start is called before the first frame update
    void Start()
    {
        foodSpawner = GetComponent<FoodSpawner>();
        behavioursVector = new Vector3[steerBehavioursParent.transform.childCount];
        steerBehaviours = new SteeringBehaviour[steerBehavioursParent.transform.childCount];

        for (int i = 0; i < steerBehaviours.Length; i++)
        {
            steerBehaviours[i] = steerBehavioursParent.transform.GetChild(i).GetComponent<SteeringBehaviour>();
        }
    }

    public Vector3 SumForces(Boid currentBoid, List<Boid> boids)
    {
        Vector3 allForces = Vector3.zero;

        for (int c = 0; c < steerBehaviours.Length; c++)
        {
            if (steerBehaviours[c].isEnabled)
            {
                behavioursVector[c] = steerBehaviours[c].GetSteer(boids, foodSpawner.currentFoods, currentBoid);
            }

        }

        for (int c = 0; c < steerBehaviours.Length; c++)
        {
            if (steerBehaviours[c].isEnabled)
            {
                allForces += behavioursVector[c] * steerBehaviours[c].weight * Time.deltaTime;
            }

        }  

        return allForces;
    }
}
