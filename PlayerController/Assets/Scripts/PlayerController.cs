using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera mainCamera;
    public Camera hoodCamera;
    public KeyCode switchKey;

    [SerializeField] private float speed = 20.0f;
    [SerializeField] private float turnSpeed = 45.0f;
    private float horizontalInput;
    private float forwardInput;

    void Update()
    {
        
        InputMoveAndRotateCar();
        ChooseCamera();
    }

    private void InputMoveAndRotateCar()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        //Mover o carro para frente baseado no input vertical
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        //Girar o carro baseado no input horizontal
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
    }

    private void ChooseCamera()
    {
        //Mudança entre câmeras
        if(Input.GetKeyDown(switchKey))
        {
            mainCamera.enabled = !mainCamera.enabled;
            hoodCamera.enabled = !hoodCamera.enabled;
        }
    }
}
