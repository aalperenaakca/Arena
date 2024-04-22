using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint;
    private float speed = 5.0f;
    private float forwardInput;
    private float rightInput;
    private bool hasPowerup = false;
    private bool hasPowerupAgain = false;
    public GameObject powerupIndicator;
    public bool onGround = true;
    [SerializeField]
    private GameObject over;
    private float powerUpTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        if(onGround) 
        {
            forwardInput = Input.GetAxis("Vertical");
            rightInput = Input.GetAxis("Horizontal");
            //playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed);
            playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed);
            playerRb.AddForce(focalPoint.transform.right * rightInput * speed);
            powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            playerRb.AddForce(Vector3.up * 7,ForceMode.Impulse);
            onGround = false;
        }

        if(transform.position.y < -15 && hasPowerup)
        {
            playerRb.velocity = new Vector3(0, 0, 0);
            playerRb.angularVelocity = new Vector3(0, 0, 0);
            transform.position = powerupIndicator.gameObject.transform.position;
            
        }
        else if(transform.position.y < -15 && !hasPowerup)
        {
            Time.timeScale = 0;
            over.SetActive(true);
        }
        if (hasPowerup)
        {
            powerUpTime -= Time.deltaTime;
        }
        if(powerUpTime < 0)
        {
            hasPowerup = false;
            powerupIndicator.gameObject.SetActive(false);

        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            powerUpTime += 5f;
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);

        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Island"))
        { 
            onGround = true;
        }


        if(hasPowerup && collision.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position-transform.position;
            enemyRb.AddForce(awayFromPlayer * 10, ForceMode.Impulse);
        }

    }

    public void GameOver()
    {
        SpawnManager.waveNumber = 0;
        SceneManager.LoadScene(0);
    }


}
