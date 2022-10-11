using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonManager : MonoBehaviour
{
   public UnityEvent buttonTrigger;

   private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")){
            buttonTrigger?.Invoke();
        }

   }
}
