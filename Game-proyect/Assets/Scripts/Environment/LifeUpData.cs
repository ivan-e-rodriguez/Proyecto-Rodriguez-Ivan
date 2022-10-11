using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeUpData : MonoBehaviour
{
    [SerializeField]
    [Range(1, 10)]
    private int healPoints = 1;
    public int HealPoints { get { return healPoints; } }
}
