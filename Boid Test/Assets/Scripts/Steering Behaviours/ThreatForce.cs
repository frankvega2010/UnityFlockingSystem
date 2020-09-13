using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreatForce : SteeringBehaviour
{
    public float perceptionRadius;
    public float maxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override Vector3 GetSteer(List<Boid> boids, List<GameObject> foods, Boid currentBoid)
    {
        if(!currentBoid.isThreat)
        {
            Vector3 desiredVelocity = Vector3.zero;
            int countNeighbour = 0;

            for (int i = 0; i < boids.Count; i++)
            {
                if (boids[i] != currentBoid)
                {
                    if(boids[i].isThreat)
                    {
                        Vector3 diff = currentBoid.gameObject.transform.position - boids[i].transform.position;
                        float dist = diff.magnitude;

                        if (dist < perceptionRadius)
                        {
                            countNeighbour++;
                            dist /= perceptionRadius;
                            desiredVelocity += diff.normalized * maxSpeed / dist;
                        }
                    }
                }
            }

            if (countNeighbour > 0)
            {
                desiredVelocity /= countNeighbour;
                Vector3 threatForce = desiredVelocity - currentBoid.velocity;
                return threatForce;
            }
            else
            {
                return Vector3.zero;
            }
        }
        else
        {
            return Vector3.zero;
        }
    }
}
