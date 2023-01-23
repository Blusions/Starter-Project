using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{

    public GameObject panel;

    public Image timeImage;

    public Text timeText;

    public float duration, currentTime;

    BallCounter ballcounter;

    public bool gameOver = false;
    // Start is called before the first frame update
    void Awake()
    {

    }

    void Start()
    {
        panel.SetActive(false);
        currentTime = duration;
        timeText.text = currentTime.ToString();
        StartCoroutine(TimeIEn());
    }

    IEnumerator TimeIEn()
    {
        while(currentTime >=0)
        {
            timeImage.fillAmount = Mathf.InverseLerp(0, duration, currentTime);
            timeText.text = currentTime.ToString();
            yield return new WaitForSeconds(1f);
            currentTime--;
        }
        OpenPanel();
    }

    void OpenPanel()
    {
        timeText.text = "";
        panel.SetActive(true);
        gameOver = true;
        SceneManager.LoadScene(3);
    }


}
