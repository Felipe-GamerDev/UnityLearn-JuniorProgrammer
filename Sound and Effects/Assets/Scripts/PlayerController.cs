using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public KeyCode inputKey;
    public float gravityModifier;
    public bool gameOver = false;
    private Rigidbody playerRigidbody;
    [SerializeField] private float jumpForce = 10;
    private bool isOnGround = true;
    private Animator playerAnim;

    private void Start() 
    {
        playerRigidbody = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
    }
    
    private void FixedUpdate() 
    {
        //Input para o personagem pular
        if(Input.GetKeyDown(inputKey) && isOnGround && !gameOver)
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision collision) 
    {
        //Ao entrar em contato com o solo, input de salto é liberado
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
        }
    }
}
