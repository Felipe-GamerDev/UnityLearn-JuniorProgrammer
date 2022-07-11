using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public KeyCode inputKey;
    public float gravityModifier;
    public bool gameOver = false;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public  AudioClip jumpSound;
    public  AudioClip crashSound;
    public bool doubleJumpUsed = false;
    public float doubleJumpForce;
    private Rigidbody playerRigidbody;
    [SerializeField] private float jumpForce = 10;
    private bool isOnGround = true;
    private Animator playerAnim;
    private AudioSource playerAudio;

    private void Start() 
    {
        playerRigidbody = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }
    
    private void FixedUpdate() 
    {
        //Input para o personagem pular
        if(Input.GetKeyDown(inputKey) && isOnGround && !gameOver)
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            doubleJumpUsed = false;
        } else if (Input.GetKeyDown(inputKey) && !isOnGround && !doubleJumpUsed)
        {
            doubleJumpUsed = true;
            playerRigidbody.AddForce(Vector3.up * doubleJumpForce, ForceMode.Impulse);
            playerAnim.Play("Running_Jump", 3, 0f);
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision) 
    {
        //Ao entrar em contato com o solo, input de salto é liberado
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
}
