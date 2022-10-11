using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static int score;
    public static int Score { get => score; set => score = value; }


    public static GameManager instance;

    private void Awake()
    {

        if (instance == null)
        {   
            instance = this;
            score = 0;
            DontDestroyOnLoad(gameObject);

            PlayerCollision.OnDead += ResetScore;
        }else
        {
            Destroy(gameObject);
        }
    }

    private void ResetScore(){
        score = 0; 
    }

    private void OnDisable() {
        PlayerCollision.OnDead -= ResetScore;
    }


}
