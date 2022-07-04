using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject foodProjectile;
    public KeyCode projectileInput;
    [SerializeField] private float speed = 10.0f;
    private float horizontalInput;
    private float offsetLimit = 15;

    private void Update() 
    {
        PlayerMove();
        MovementLimitPlayer();
        LaunchFoodProjectile();
    }

    private void PlayerMove()
    {
        //Movimentar o jogador para os lados com input
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
    }
    
    private void MovementLimitPlayer()
    {
        //Manter o jogador dentro dos limites
        if(transform.position.x < -offsetLimit)
        {
            transform.position = new Vector3(-offsetLimit, transform.position.y, transform.position.z);
        }
        if(transform.position.x > offsetLimit)
        {
            transform.position = new Vector3(offsetLimit, transform.position.y, transform.position.z);
        }
    }
    
    private void LaunchFoodProjectile()
    {
        //Launch a projectile from the player
        if(Input.GetKeyDown(projectileInput))
        {
            Instantiate(foodProjectile, transform.position, foodProjectile.transform.rotation);
        }
    }
}
