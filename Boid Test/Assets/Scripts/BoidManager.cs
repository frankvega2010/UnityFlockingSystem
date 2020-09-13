using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidManager : MonoBehaviour
{
    public GameObject boidPrefab;
    public GameObject threatPrefab;
    public List<GameObject> boidsGO;
    public SteerManager steerManager;

    public List<Boid> boids;
    // Start is called before the first frame update
    void Start()
    {
        EatFoodForce.OnBoidEatenFood += TransformIntoThreat;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            SpawnBoid(false);
        }

        if (Input.GetMouseButtonDown(1))
        {
            SpawnBoid(true);
        }

        if (boids.Count > 0)
        {
            for (int i = 0; i < boids.Count; i++)
            {
                boids[i].velocity += steerManager.SumForces(boids[i], boids);

                boids[i].mesh.transform.rotation = Quaternion.FromToRotation(Vector3.forward, boids[i].velocity*Time.deltaTime);

                if (boids[i].hasCollided)
                {
                    boids[i].transform.position += (boids[i].velocity * -1) * Time.deltaTime;
                }
                else
                {
                    boids[i].transform.position += boids[i].velocity * Time.deltaTime;
                }

            }
        }
    }

    public void SpawnBoid(bool isThreat)
    {
        GameObject newBoid;

        if(isThreat)
        {
            newBoid = Instantiate(threatPrefab);
        }
        else
        {
            newBoid = Instantiate(boidPrefab);
        }
        newBoid.GetComponent<Boid>().setRandomPosition = true;
        boidsGO.Add(newBoid);
        boids.Add(newBoid.GetComponent<Boid>());
    }

    public void SpawnBoid(bool isThreat, Vector3 pos)
    {
        GameObject newBoid;

        if (isThreat)
        {
            newBoid = Instantiate(threatPrefab);
        }
        else
        {
            newBoid = Instantiate(boidPrefab);
        }
        newBoid.GetComponent<Boid>().setRandomPosition = false;
        newBoid.gameObject.transform.position = pos;
        boidsGO.Add(newBoid);
        boids.Add(newBoid.GetComponent<Boid>());
    }

    public void TransformIntoThreat(Boid currentBoid)
    {
        Vector3 newPos = currentBoid.gameObject.transform.position;
        boidsGO.Remove(currentBoid.gameObject);
        boids.Remove(currentBoid);
        Destroy(currentBoid.gameObject);

        SpawnBoid(true, newPos);
    }

    public void TransformIntoBoid(Boid currentBoid)
    {
        Vector3 newPos = currentBoid.transform.position;
        boidsGO.Remove(currentBoid.gameObject);
        boids.Remove(currentBoid);
        Destroy(currentBoid.gameObject);

        SpawnBoid(false, newPos);
    }

    private void OnDestroy()
    {
        EatFoodForce.OnBoidEatenFood -= TransformIntoThreat;
    }
}
