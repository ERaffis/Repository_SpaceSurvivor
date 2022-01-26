using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


//Gère le UI lors du jeu
public class UIManager : MonoBehaviour
{
    public TMP_Text timer;
    private float startTime;

    public TMP_Text scoreText;
    public int score;

    public TMP_Text equippedGun;
    public TMP_Text healthText;


    public TMP_Text finalScoreText;
    public TMP_Text finalTimeText;

    public GameObject player;
    public GameObject playHUD;
    public GameObject deathHUD;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        score = 0;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Si le joueur est encore en vie
        if(player)
        {
            float t = Time.time - startTime;
            string minutes = ((int) t / 60).ToString();
            string seconds = (t % 60).ToString("f0");

            timer.SetText(minutes + " : " + seconds );

            string health = player.GetComponent<StateManager>().health.ToString();
            equippedGun.SetText(player.GetComponent<GunManager>().equippedGun.GunName);
            healthText.SetText(health + " / 250");
        }
        //Si le joueur est mort
        if(!player)
        {
            deathHUD.SetActive(true);
            playHUD.SetActive(false);
            finalScoreText.SetText("Final score : " + score);
            finalTimeText.SetText("Final time : " + timer.text);
        }


    }

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SoundManagerScript.audioSrc.Stop();
        GameObject music = GameObject.FindGameObjectWithTag("BackgroundMusic");
        music.GetComponent<AudioSource>().mute = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
