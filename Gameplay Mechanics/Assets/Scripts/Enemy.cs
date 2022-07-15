using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Script para mover o inimigo em direção do jogador.

    [SerializeField] private float speed;
    private Rigidbody enemyRigidbody;
    private GameObject player;

    private void Start() 
    {
        enemyRigidbody = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    private void FixedUpdate() 
    {
        EnemyFollowPlayer();
        if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    private void EnemyFollowPlayer()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRigidbody.AddForce(lookDirection * speed);
    }
}
