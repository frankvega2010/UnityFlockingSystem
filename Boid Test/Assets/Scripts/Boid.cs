using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Boid : MonoBehaviour
{
    

    //public SteerManager steerManager;
    public Vector3 velocity;
    public float speed;
    public float minSpeed;
    public float maxSpeed;
    public bool hasCollided;
    public bool isThreat;
    public bool setRandomPosition;
    public int foodEaten;
    public int waypointIndex;
    public GameObject mesh;

    // Start is called before the first frame update
    void Start()
    {
        // perceptionRadius = 40;
        // separationPerceptionRadius = 25;
        float angle = Random.Range(0, (2 * 3.1416f));
        speed = Random.Range(minSpeed, maxSpeed);
        velocity = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle),1) * speed;
        if(setRandomPosition)
        {
            transform.position = new Vector3(Random.Range(0, 40), Random.Range(0, 40), Random.Range(0, 40));
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 separationForce = GetSeparationForce
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "pared")
        {
            hasCollided = !hasCollided;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.tag == "pared")
        {
            hasCollided = !hasCollided;
        }
    }
}
