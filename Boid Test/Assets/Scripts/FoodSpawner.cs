using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [Header("Config")]
    public GameObject foodPrefab;
    public float YSpawnPosition;
    public GameObject spawnParent;
    public float spawnMinInterval;
    public float spawnMaxInterval;

    [Header("View Variables")]
    public float intervalTimer;
    public float nextInterval;
    public Vector3[] spawnLocations;
    public List<GameObject> currentFoods;
    // Start is called before the first frame update
    void Start()
    {
        spawnLocations = new Vector3[spawnParent.transform.childCount];

        for (int i = 0; i < spawnLocations.Length; i++)
        {
            spawnLocations[i] = spawnParent.transform.GetChild(i).transform.position;
        }

        Food.OnFoodDestroyed += RemoveFoodFromList;
        nextInterval = 0;
        intervalTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        intervalTimer += Time.deltaTime;

        if(intervalTimer >= nextInterval)
        {
            intervalTimer = 0;
            SpawnFood();
        }
    }

    private void SpawnFood()
    {
        int randomIndex = Random.Range(0, spawnLocations.Length);

        GameObject newFood = Instantiate(foodPrefab);
        newFood.transform.position = spawnLocations[randomIndex];
        newFood.transform.position = new Vector3(newFood.transform.position.x, YSpawnPosition, newFood.transform.position.z);
        currentFoods.Add(newFood);

        nextInterval = Random.Range(spawnMinInterval, spawnMaxInterval);
    }

    private void RemoveFoodFromList(GameObject food)
    {
        if(food)
        {
            currentFoods.Remove(food);
        }
        
    }

    private void OnDestroy()
    {
        Food.OnFoodDestroyed -= RemoveFoodFromList;
    }
}
