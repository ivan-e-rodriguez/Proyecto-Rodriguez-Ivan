using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject prefab;
    public float waitingTime = 2f;
    public float repetitionTime = 2f;

    void Start()
    {
        InvokeRepeating("SpawnObject", waitingTime, repetitionTime);
    }

    void Update()
    {

    }

    private void SpawnObject()
    {
        Instantiate(prefab, transform);
    }
}
