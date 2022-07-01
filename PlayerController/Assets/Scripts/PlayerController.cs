using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 20.0f;
    [SerializeField] private float turnSpeed = 45.0f;
    private float horizontalInput;
    private float forwardInput;

    void Start()
    {
        
    }

    
    void Update()
    {
        
        InputMoveRotateCar();
    }

    private void InputMoveRotateCar()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        //Mover o carro para frente baseado no input vertical
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        //Rodar o carro baseado no input horizontal
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
    }
}
