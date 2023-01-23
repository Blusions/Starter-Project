using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    float horizontal; 
    float vertical;
    Animator animator;
    public int value;

    Countdown countdown;

    Vector2 movement;

    public AudioClip collectSound;
    public AudioSource audioSource;

    
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
        audioSource = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + 4.0f * horizontal * Time.deltaTime;
        position.y = position.y + 4.0f * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
            other.gameObject.SetActive(false);
            BallCounter.instance.IncreaseBalls(value);   
        }
    }
}
