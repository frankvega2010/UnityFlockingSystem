using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CohesionForce : SteeringBehaviour
{
    public float perceptionRadius;
    public float separationMaxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override Vector3 GetSteer(List<Boid> boids, List<GameObject> foods, Boid currentBoid)
    {
        Vector3 desiredVelocity = Vector3.zero;
        int countNeighbour = 0;

        for (int i = 0; i < boids.Count; i++)
        {
            if (boids[i] != currentBoid)
            {
                Vector3 diff = currentBoid.gameObject.transform.position - boids[i].transform.position;
                float dist = diff.magnitude;

                if (dist < perceptionRadius)
                {
                    countNeighbour++;
                    desiredVelocity += boids[i].transform.position;
                }
            }
        }

        if (countNeighbour > 0)
        {
            desiredVelocity /= countNeighbour;
            Vector3 cohesionForce = (desiredVelocity.normalized * separationMaxSpeed) - currentBoid.velocity;
            return cohesionForce;
        }
        else
        {
            return Vector3.zero;
        }
    }
}
