using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float verticalInput;
    [SerializeField] private Rigidbody playerRb;
    [SerializeField] private GameObject focalPoint;
    [SerializeField] private bool powerUp = false;
    [SerializeField] private float powerUpSpeed = 10f;
    [SerializeField] GameObject powerupIndicator;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }
    void Update()
    {
        PlayerMove();
        powerupIndicator.transform.position = transform.position+ new Vector3(0,-0.5f,0);
    }

    // Pc controller
    void PlayerMove()
    {
        verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * verticalInput);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Powerup")
        {
            powerUp = true;
            Destroy(other.gameObject);
            powerupIndicator.gameObject.SetActive(true);
            StartCoroutine(PowerUpCount());
        }
    }
    IEnumerator PowerUpCount()
    {
        yield return new WaitForSeconds(5f);
        powerUp = false;
        powerupIndicator.gameObject.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Enemy"&&powerUp)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 enemyAway = collision.gameObject.transform.position - transform.position;
            enemyRb.AddForce(enemyAway * powerUpSpeed, ForceMode.Impulse);

        }
    }
}
