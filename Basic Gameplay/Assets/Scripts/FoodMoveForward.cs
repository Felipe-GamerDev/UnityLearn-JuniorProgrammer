using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMoveForward : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    
    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
