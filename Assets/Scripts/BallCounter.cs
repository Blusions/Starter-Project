using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BallCounter : MonoBehaviour
{
    public static BallCounter instance;

    public TMP_Text ballsText;
    public int currentBalls = 0;
    public GameObject winText;
    Countdown countdown;

    public bool gameOver = false;

    AudioSource audioSource;

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        ballsText.text = "Balls Collected: " + currentBalls.ToString();
        winText.SetActive(false);

        audioSource = GetComponent<AudioSource>();
    }

    public void IncreaseBalls(int v)
    {
        currentBalls += v;
        ballsText.text = "Balls Collected: " + currentBalls.ToString();
        if(currentBalls >= 6)
        {
            winText.SetActive(false);
            gameOver = true;
            SceneManager.LoadScene(2);
        }
    }

    public void PlaySound(AudioClip collectSound)
    {
        audioSource.PlayOneShot(collectSound);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.R))
            {
                if (gameOver == true)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
    }
}
