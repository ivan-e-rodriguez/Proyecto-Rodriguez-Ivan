using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerCollision : MonoBehaviour
{
    private PlayerData playerData;
    private PlayerMoveForce playerMove;

    public static event Action OnDead; 

    public static event Action OnVictory;   
    private void Start()
    {
        playerData = GetComponent<PlayerData>();
        playerMove = GetComponent<PlayerMoveForce>();
    }

    private void OnCollisionEnter(Collision other)
    {
          if (other.gameObject.CompareTag("Bullets"))
        {
                Destroy(other.gameObject);
                playerData.Damage(other.gameObject.GetComponent<ObstaculeData>().DamagePoints);
                if (playerData.HP <= 0)
                {
                     PlayerCollision.OnDead?.Invoke();   
                     transform.position = playerData.StartPosition;
                     playerData.Healing(playerData.MaxLives);
                     HUDmanager.Refill();
                }

                HUDmanager.GetDamage(playerData.HP);
                GameManager.Score--;
                HUDmanager.Instance.SetScore(GameManager.Score);
                
        }

          if (other.gameObject.CompareTag("Spikes"))
        {          
                GameManager.Score--;
                HUDmanager.Instance.SetScore(GameManager.Score);
                playerData.Damage(other.gameObject.GetComponent<ObstaculeData>().DamagePoints);
                if (playerData.HP <= 0)
                {
                     PlayerCollision.OnDead?.Invoke();     
                     transform.position = playerData.StartPosition;
                     playerData.Healing(playerData.MaxLives);
                     HUDmanager.Refill();
                }

                HUDmanager.GetDamage(playerData.HP);
        }
     
    }

    private void OnCollisionExit(Collision other)
    {
    
    }

    private void OnCollisionStay(Collision other)
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
          if (other.gameObject.CompareTag("Jewel"))
        {        
                Destroy(other.gameObject);  
                GameManager.Score++;
                HUDmanager.Instance.SetScore(GameManager.Score);

                if(GameManager.Score == 5){
                        PlayerCollision.OnVictory?.Invoke();
                }
        }  

          if (other.gameObject.CompareTag("Life"))
        {          
                Destroy(other.gameObject);
                playerData.Healing(other.gameObject.GetComponent<LifeUpData>().HealPoints);
                HUDmanager.GetHeal(playerData.HP - 1);

        } 

    }

    private void OnTriggerExit(Collider other)
    {

    }

    private void OnTriggerStay(Collider other)
    {

    }

    private void OnControllerColliderHit(ControllerColliderHit hit) {
     
    }
}
