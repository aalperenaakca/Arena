using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 3.5f;
    private Rigidbody enemyRb;
    private GameObject player;
    Vector3 lookDirection;
    // Start is called before the first frame update
    void Start()
    {
        
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        lookDirection = (player.transform.position - transform.position).normalized;
        lookDirection.y = 0;
        enemyRb.AddForce( lookDirection * speed);

        if(transform.position.y < -15)
        {
            Destroy(gameObject);
        }
        if (transform.position.y < -0.3)
        {
            enemyRb.mass = 1000f;
        }
        if (transform.position.y > 0.1f)
        {
            transform.position = new Vector3(transform.position.x, 0.1f, transform.position.z);
        }
    }
}
