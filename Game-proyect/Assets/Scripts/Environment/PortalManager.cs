using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{

    [SerializeField]
    [Range(2, 10)]
    private float cooldown;

    [SerializeField]
    Transform nextPortal;

    private float timeInPortal = 0;

    private void OnTriggerEnter(Collider other)
    {
        timeInPortal = 0;
    }

    private void OnTriggerExit(Collider other)
    {

    }

    private void OnTriggerStay(Collider other)
    {
        timeInPortal += Time.deltaTime;
        Debug.Log(timeInPortal);
        if (timeInPortal >= cooldown)
        {
            other.transform.position = nextPortal.position;
        }

    }
}
