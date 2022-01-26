using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamageManager : MonoBehaviour
{

    public GameObject player;
    public GameObject ui;
    public string damageableObject;

    private void Awake() 
    {
        player = GameObject.Find("Player");
        ui = GameObject.Find("UI");

    }


    private void OnTriggerEnter(Collider other) 
    {  if(player)
        {
            if (damageableObject == other.tag)
            {
                // Quand le joueur tire un ennemi
                if(other.tag == "Enemy")
                {
                    if(player.GetComponent<GunManager>().equippedGun.GunName != "Beam")
                    {
                        Destroy(this.gameObject);
                    }
                        
                    other.gameObject.GetComponent<Enemies>().enemyHealth -= player.GetComponent<GunManager>().equippedGun.GunDamage;
                    other.gameObject.GetComponent<Enemies>().healthBar.value =  other.gameObject.GetComponent<Enemies>().enemyHealth;

                    if(other.gameObject.GetComponent<Enemies>().enemyHealth <= 0)
                    {
                        Destroy(other.gameObject);
                        ui.GetComponent<UIManager>().score +=10;
                        ui.GetComponent<UIManager>().scoreText.SetText("Score : " + ui.GetComponent<UIManager>().score);
                    }
                }     

                // Quan un ennemi fait des dégats au joueur
                if(other.tag == "Player")
                {
                    if(this.gameObject.tag == "Enemy-Laser")
                    {
                        print("playerhit - Ship");
                        Destroy(this.gameObject);
                        other.gameObject.GetComponent<StateManager>().health -= 10;
                        other.gameObject.GetComponent<StateManager>().healthBar.value =  other.gameObject.GetComponent<StateManager>().health;

                        if(other.gameObject.GetComponent<StateManager>().health <= 0)
                        {
                            Destroy(other.gameObject);
                            GameObject music = GameObject.FindGameObjectWithTag("BackgroundMusic");
                            music.GetComponent<AudioSource>().mute = true;
                            SoundManagerScript.PlaySound("deathJingle");
                        }
                    } else
                    {
                        print("playerhit");
                        Destroy(this.gameObject);
                        other.gameObject.GetComponent<StateManager>().health -= this.GetComponent<Enemies>().enemyDamage;
                        other.gameObject.GetComponent<StateManager>().healthBar.value =  other.gameObject.GetComponent<StateManager>().health;

                        if(other.gameObject.GetComponent<StateManager>().health <= 0)
                        {
                            Destroy(other.gameObject);
                            Destroy(GameObject.FindGameObjectWithTag("BackgroundMusic"));
                            SoundManagerScript.PlaySound("deathJingle");
                            
                        }
                    }
                }
            }
        }
    }
}
