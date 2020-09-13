using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SteeringBehaviour : MonoBehaviour
{
    public bool isEnabled;
    [Range(0,1)]
    public float weight;

    public abstract Vector3 GetSteer(List<Boid> boids, List<GameObject> foods, Boid currentBoid);
}
