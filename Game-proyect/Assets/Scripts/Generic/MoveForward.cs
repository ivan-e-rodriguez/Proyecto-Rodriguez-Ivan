using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 2f;

    public float liveTime = 3f;

    void Start()
    {
        Invoke("DestroyDelay", liveTime);
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void DestroyDelay()
    {
        Debug.Log("DESTROY DELAY");
        Destroy(gameObject);
    }
}
