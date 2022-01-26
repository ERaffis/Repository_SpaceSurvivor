using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemies : MonoBehaviour
{
    

    [Header ("Enemies Variables")]
    public string ennemyName;
    public GameObject playerCible;
    public int enemyHealth;
    public int enemySpeed;
    public int enemyDamage;
    public Slider healthBar;
    public Rigidbody rb;



    private void Start() 
    {
        playerCible = GameObject.Find("Player");
    }


    

}
