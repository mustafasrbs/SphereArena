using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] GameObject player;
    [SerializeField] private Rigidbody rb;
    void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        move();
        if (transform.position.y<-10)
        {
            Destroy(gameObject);
        }
        
    }
    void move()
    {
        rb.AddForce((player.transform.position - transform.position).normalized * speed);
        
    }
}
