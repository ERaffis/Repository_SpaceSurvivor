using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Class qui gère la vie
public class LifeManager : MonoBehaviour
{
    public Slider healthbar;

    public void SetHealth(int health)
    {
        healthbar.value = health;
    }
}
