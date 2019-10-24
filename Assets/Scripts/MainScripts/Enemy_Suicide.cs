﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Suicide : MonoBehaviour
{
    public GameObject ExplosionBP;
    public Transform here;
    public Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float moveSpeed = 5f;
    public float stoppingDistance;
    public float retreatDistance;
    



    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        Movement();
        LookAt();
    }

    void Movement()
    {
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            rb.AddForce(transform.up * moveSpeed * 2);
        }
        //If the enemy is too close to the player but not close enough to retreat, the enemy gain nor lose velocity.
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && (Vector2.Distance(transform.position, player.position) > retreatDistance))
        {
            transform.position = this.transform.position;
        }
        //If the enemy is too close to the player, the enemy will retreat.
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            rb.AddForce(transform.up * -moveSpeed);
        }
    }
    void LookAt()
    {
        //Looks at the player.
        var addAngle = 270;
        var dir = player.position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + addAngle;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Player Bullets"))
        {
            //Destroys the ship and explodes.
            Destroy(gameObject);
            GameObject clone = (GameObject)Instantiate(ExplosionBP, here.position, here.rotation);
        }
    }
}
