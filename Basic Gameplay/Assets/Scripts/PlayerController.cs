using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject foodProjectile;
    public KeyCode projectileInput;
    public Transform projectileSpawnPoint;

    [SerializeField] private float speed = 20;
    private float horizontalInput;
    private float verticalInput;
    [SerializeField] private float xOffsetLimit = 15;
    [SerializeField] private float zOffsetLimitMin = -1.5f;
    [SerializeField] private float zOffsetLimitMax = 15.5f;

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

        //Movimentar o jogador para frente e atrás com input
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
    }
    
    private void MovementLimitPlayer()
    {
        //Manter o jogador dentro dos limites(lados)
        if(transform.position.x < -xOffsetLimit)
        {
            transform.position = new Vector3(-xOffsetLimit, transform.position.y, transform.position.z);
        }
        if(transform.position.x > xOffsetLimit)
        {
            transform.position = new Vector3(xOffsetLimit, transform.position.y, transform.position.z);
        }

        //Manter o jogador dentro dos limites(frente e atrás)
        if(transform.position.z < zOffsetLimitMin)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zOffsetLimitMin);
        }
        if(transform.position.z > zOffsetLimitMax)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zOffsetLimitMax);
        }
    }
    
    private void LaunchFoodProjectile()
    {
        //Launch a projectile from the player
        if(Input.GetKeyDown(projectileInput))
        {
            Instantiate(foodProjectile, projectileSpawnPoint.position, foodProjectile.transform.rotation);
        }
    }
}
