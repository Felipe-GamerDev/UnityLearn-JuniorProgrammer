using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardMove : MonoBehaviour
{
   [SerializeField] private float speed = 10;
    void Update()
    {
        //Mover o ônibus
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        //Destruir o ônibus ao ultrapassar o limite(-20)
        if(gameObject.transform.position.z < -20)
        {
            Destroy(gameObject);
        }
    }
}
