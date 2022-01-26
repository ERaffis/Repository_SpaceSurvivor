using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteEnemy : Enemies
{


    private void Update() 
    {
        CheckVelocity();
    }

    private void FixedUpdate() 
    {
        if(playerCible)
        {
            rb.AddForce((playerCible.transform.position-this.transform.position) * enemySpeed);
        }
        
    }

    //Fait avancer les meteorite vers le joueur
    private void CheckVelocity()
    {
        if(rb.velocity.x > 10)
        {
            rb.velocity = new Vector2 (10, rb.velocity.y);
        }
        if(rb.velocity.y> 10)
        {
            rb.velocity = new Vector2 (rb.velocity.x, 10);
        }
    }

}
