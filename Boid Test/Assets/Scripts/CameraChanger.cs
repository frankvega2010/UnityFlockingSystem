using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChanger : MonoBehaviour
{
    public GameObject cameraPrefab;
    public GameObject[] cameras;
    public BoidManager boidManager;

    // Start is called before the first frame update
    void Start()
    {
        boidManager = GetComponent<BoidManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetCamera(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetCamera(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetCamera(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SetCamera(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SetCamera(4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            SetCamera(5);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            SetCamera(6);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            SetCamera(7);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            SetCameraRandomBoid();
        }
    }

    public void SetCamera(int index)
    {
        if(!cameras[index])
        {
            cameras[index] = Instantiate(cameraPrefab);
        }
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].SetActive(false);
        }
        cameras[index].SetActive(true);
    }

    public void SetCameraRandomBoid()
    {
        SetCamera(cameras.Length-1);
        if(boidManager.boidsGO.Count > 0)
        {
            cameras[cameras.Length - 1].transform.SetParent(boidManager.boidsGO[0].transform.GetChild(0).transform.GetChild(0));
            cameras[cameras.Length - 1].transform.localRotation = Quaternion.identity;
            cameras[cameras.Length - 1].transform.localPosition = Vector3.zero;
        }
    }
}
