using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculeData : MonoBehaviour
{
    [SerializeField]
    [Range(1, 10)]
    private int damagePoints = 1;
    public int DamagePoints { get { return damagePoints; } }
}
