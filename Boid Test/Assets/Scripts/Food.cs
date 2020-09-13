using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public delegate void OnFoodAction(GameObject food);
    public static OnFoodAction OnFoodDestroyed; 

    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, -moveSpeed, 0) * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "pared")
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (OnFoodDestroyed != null)
        {
            OnFoodDestroyed(gameObject);
        }
    }
}
