using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Orienté objet style polymorphisme
public class ShipEnemy : Enemies
{
    [Header ("Ship Enemy Variables")]
    public GameObject bulletPrefab;
    public int fireRate;
    public int gunSpeed;
    public bool isCircling;
    public GameObject gunPoint;
    
    
    private float width     = 5f;
    private float height    = 5f;
    private float timer     = 2.5f;
    private float timeCounter;


    private void Awake() 
    {
        isCircling = false;
    }
    
    private void Update() 
    {
        timer -= Time.deltaTime;
        
        
        if(playerCible)
        {
            LookAtCible();
            ShootPlayer();
            CheckVelocity();
            MoveShip();
        }
    }

    //Véfirie que la vitesse n'est pas trop haute
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

    //Fait tourner le vaisseau autour du joueur
    private void Circle()
    {
        timeCounter += Time.smoothDeltaTime * enemySpeed;
        float x = Mathf.Cos(timeCounter) * width;
        float y = Mathf.Sin(timeCounter) * height;

        transform.position = new Vector2  (x + playerCible.transform.position.x, y + playerCible.transform.position.y);

    }

    //Fait bouger le vaisseau vers le joueur et autour du joueur
    private void MoveShip()
    {
        Vector2 dist = playerCible.transform.position-this.transform.position;

        if(dist.x >= 7.5f || dist.x <= -7.5f || dist.y >= 7.5f || dist.y <= -7.5f)
        {
            rb.AddForce((dist) * enemySpeed);
        } else  if (!isCircling)
        {
            
            StartCoroutine(WaitForCircling());

        } else if (isCircling)
        {
            Circle();  
        }

        //Prevent the healthbar from rotating
        healthBar.transform.position = this.transform.position + new Vector3(0,0.75f,0);
        healthBar.transform.rotation = Quaternion.Euler (0.0f, 0.0f, gameObject.transform.rotation.z * -1.0f);
    }

    //Fonction qui fait regarder le joueur
    private void LookAtCible()
    {
        Vector3 dir = playerCible.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    //Fonction qui tire sur le joueur si l'en
    void ShootPlayer()
    {
        if (timer <= 0 && isCircling)
        {
            GameObject bullet = Instantiate(bulletPrefab, gunPoint.transform.position, gunPoint.transform.rotation);        
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(gunPoint.transform.up * gunSpeed, ForceMode.Impulse);
            Destroy(bullet, 2f);
            timer = 2.5f;

            
        }        
    }

    //Transition lorsque le vaisseau commence à tourner
    IEnumerator WaitForCircling()
    {   
        
        transform.localScale = Vector3.Lerp (transform.localScale, new Vector3(0,0,0), Time.deltaTime * 5);
        yield return new WaitForSeconds(.25f);

        float x = Mathf.Cos(timeCounter) * width;
        float y = Mathf.Sin(timeCounter) * height;

        transform.position = new Vector2  (x + playerCible.transform.position.x, y + playerCible.transform.position.y);

        yield return new WaitForSeconds(.25f);
        
        isCircling = true;
        transform.localScale = Vector3.Lerp (transform.localScale, new Vector3(1,1,1), Time.deltaTime * 5);
        

    }
}
