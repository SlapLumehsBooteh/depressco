﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Temporary vector
        Vector3 temp = player.transform.position;
        temp.z = -20;
        // Assign value to Camera position
        transform.position = temp;
    }
}
