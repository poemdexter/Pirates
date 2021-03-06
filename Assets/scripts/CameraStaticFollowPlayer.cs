﻿using UnityEngine;
using System.Collections;

public class CameraStaticFollowPlayer : MonoBehaviour
{
    Transform player;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
	
    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
