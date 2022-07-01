using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offeset = new  Vector3(0, 5, -7.5f);

    void LateUpdate()
    {
        transform.position = player.transform.position + offeset;
    }
}
