using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeparationForce : SteeringBehaviour
{
    public float separationPerceptionRadius;
    public float separationMaxSpeed;

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

                if (dist < separationPerceptionRadius)
                {
                    countNeighbour++;
                    dist /= separationPerceptionRadius;
                    desiredVelocity += diff.normalized * separationMaxSpeed / dist;
                }
            }
        }

        if (countNeighbour > 0)
        {
            desiredVelocity /= countNeighbour;
            Vector3 separationForce = desiredVelocity - currentBoid.velocity;
            return separationForce;
        }
        else
        {
            return Vector3.zero;
        }
     }
}
