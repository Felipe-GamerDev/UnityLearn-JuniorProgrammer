using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public KeyCode inputKey;
    public float gravityModifier;
    private Rigidbody playerRigidbody;
    [SerializeField] private float jumpForce = 10;
    private bool isOnGround = true;

    private void Start() 
    {
        playerRigidbody = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }
    
    private void FixedUpdate() 
    {
        //Input para o personagem pular
        if(Input.GetKeyDown(inputKey) && isOnGround)
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision) 
    {
        //Ao entrar em contato com o solo, input de salto é liberado
        isOnGround = true; 
    }
}
