using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameObject focalPoint;
    private Rigidbody playerRigibody;
    [SerializeField] private float speed = 5.0f;

    private void Start() 
    {
        playerRigibody = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    private void FixedUpdate() 
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRigibody.AddForce(focalPoint.transform.forward * speed * forwardInput *Time.fixedDeltaTime);
    }
}
