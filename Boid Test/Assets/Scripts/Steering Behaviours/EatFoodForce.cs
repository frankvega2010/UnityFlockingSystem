using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatFoodForce : SteeringBehaviour
{
    public delegate void OnBoidAction(Boid boid);
    public static OnBoidAction OnBoidEatenFood;

    public float perceptionRadius;
    public float maxSpeed;
    public float eatDistance;
    public int maxFoodEaten;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /*// Update is called once per frame
    void Update()
    {
        
    }*/

    public override Vector3 GetSteer(List<Boid> boids, List<GameObject> foods, Boid currentBoid)
    {
        if(!currentBoid.isThreat)
        {
            Vector3 desiredVelocity = Vector3.zero;
            int countNeighbour = 0;

            for (int i = 0; i < foods.Count; i++)
            {
                Vector3 diff = currentBoid.transform.position - foods[i].transform.position;
                float dist = diff.magnitude;

                if (dist < perceptionRadius)
                {
                    countNeighbour++;
                    Vector3 desiredPosition = foods[i].transform.position - currentBoid.transform.position;

                    Vector3 distance = (desiredPosition.normalized * currentBoid.speed) - currentBoid.velocity;

                    if (Vector3.Distance(currentBoid.transform.position, foods[i].transform.position) < eatDistance)
                    {
                        Destroy(foods[i].gameObject);
                        currentBoid.foodEaten++;
                        if(currentBoid.foodEaten >= maxFoodEaten)
                        {
                            Debug.Log("there is a new threat now!");
                            if (OnBoidEatenFood != null)
                            {
                                OnBoidEatenFood(currentBoid);
                            }
                        }

                        Debug.Log("food eaten");
                    }

                    return distance;

                    //waypointForce = distance;
                }
            }

            /*if (countNeighbour > 0)
            {
                return threatForce;
            }
            else
            {
                return Vector3.zero;
            }*/
            return Vector3.zero;
        }
        else
        {
            return Vector3.zero;
        }
    }
}
