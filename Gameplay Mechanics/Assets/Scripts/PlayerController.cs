using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool hasPowerup;
    public GameObject powerupIndicator;
    private GameObject focalPoint;
    private Rigidbody playerRigibody;
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float powerupStrength = 20.0f;

    private void Start() 
    {
        playerRigibody = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    private void FixedUpdate() 
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRigibody.AddForce(focalPoint.transform.forward * speed * forwardInput *Time.fixedDeltaTime);

        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("PowerUp"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
            powerupIndicator.gameObject.SetActive(true);
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(5);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (other.gameObject.transform.position - transform.position);

            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            
            //Personalizado
            hasPowerup = false;
            powerupIndicator.gameObject.SetActive(false);
        }
    }
}
