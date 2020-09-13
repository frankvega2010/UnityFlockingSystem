using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignForce : SteeringBehaviour
{
    public float perceptionRadius;

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
                    desiredVelocity += boids[i].velocity;
                }
            }
        }

        if (countNeighbour > 0)
        {
            desiredVelocity /= countNeighbour;
            Vector3 alignForce = desiredVelocity - currentBoid.velocity;
            return alignForce;
        }
        else
        {
            return Vector3.zero;
        }
    }
}
