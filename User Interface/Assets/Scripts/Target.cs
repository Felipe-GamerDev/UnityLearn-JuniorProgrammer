using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    //Script para movimentação dos alvos, destruir em caso de click ou contato com o trigger do sensor e pontuação.

    public int pointValue;
    public ParticleSystem explosionParticle;
    private Rigidbody targetRigidbody;
    private float minSpeed = 14;
    private float maxSpeed = 17;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawPos = -6;
    private GameManager gameManager;

    private void Start() 
    {
        targetRigidbody = GetComponent<Rigidbody>();
        targetRigidbody.AddForce(RandomForce(), ForceMode.Impulse);
        targetRigidbody.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    private float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    private Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawPos);
    }

    private void OnMouseDown() 
    {
        if(gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UptadeScore(pointValue);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        Destroy(gameObject);
        if(!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }
}
