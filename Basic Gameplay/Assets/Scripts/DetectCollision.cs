using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
       if (other.CompareTag("Player"))
       {
        Debug.Log("Game over!");
        Destroy(gameObject);
       } 
       else 
       {
        Destroy(gameObject);
        Destroy(other.gameObject);
       }
    }
}
