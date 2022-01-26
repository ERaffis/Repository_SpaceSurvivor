using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    public GameObject gunPoint;
    public GameObject bombPoint;
    public Gun equippedGun;
    public List <Gun> gunList = new List<Gun>();

    public int gunIndex;
    public bool canShoot;


    public void Start()
    {
        gunList.Add(Gun.GunDictionary["Laser"]);
        gunList.Add(Gun.GunDictionary["Bomb"]);
        gunList.Add(Gun.GunDictionary["Big Laser"]);
        gunList.Add(Gun.GunDictionary["Flak Cannon"]);
        gunList.Add(Gun.GunDictionary["Beam"]);

        canShoot = true;
        gunIndex = 0;
        equippedGun = gunList[gunIndex];
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canShoot || Input.GetMouseButtonDown(0) && canShoot )
        {
            SoundManagerScript.PlaySound("laser");
            StartCoroutine(BulletDelay());
            
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            gunIndex++;
            if (gunIndex >= (gunList.Count))
            {
                gunIndex = 0;
                equippedGun = gunList[gunIndex];
                canShoot = true;
            }

            else
            {
                equippedGun = gunList[gunIndex];
                canShoot = true;
            }

        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            gunIndex--;
            if (gunIndex < (0))
            {
                gunIndex = gunList.Count-1;
                equippedGun = gunList[gunIndex];
                canShoot = true;
            }

            else
            {
                equippedGun = gunList[gunIndex];
                canShoot = true;
            }

        }
        
    }

    //Instantiate des différents type de bullet
    public void InstantiateBullet(string gunName)
    {
        switch (gunName)
        {
            case "Flak Cannon":
                float offset = -20f;

                for (int i = 0; i < 3; i++)
                {
                    GameObject bullet = Instantiate(equippedGun.BulletPrefab, gunPoint.transform.position, gunPoint.transform.rotation);
                    Rigidbody rb = bullet.GetComponent<Rigidbody>();
                    rb.AddForce(Quaternion.AngleAxis(offset, Vector3.forward) *  transform.up * equippedGun.BulletSpeed, ForceMode.Impulse);
                    Destroy(bullet,5f);
                    offset += 20;
                }
                StartCoroutine(BulletCooldown());

            break;
            
            case "Bomb":
                
                float offset1 = -20f;

                for (int i = 0; i < 3; i++)
                {
                    GameObject bullet = Instantiate(equippedGun.BulletPrefab, bombPoint.transform.position , gunPoint.transform.rotation);
                    Rigidbody rb = bullet.GetComponent<Rigidbody>();
                    rb.AddForce(Quaternion.AngleAxis(offset1, Vector3.forward) *  transform.up * -1 * equippedGun.BulletSpeed, ForceMode.Impulse);
                    Destroy(bullet,5f);
                    offset1 += 20;
                }
                StartCoroutine(BulletCooldown());

            break;

            case "Beam":
                GameObject bullet2 = Instantiate(equippedGun.BulletPrefab, gunPoint.transform.position, gunPoint.transform.rotation);
                Rigidbody rb2 = bullet2.GetComponent<Rigidbody>();
                rb2.AddForce(gunPoint.transform.up * equippedGun.BulletSpeed, ForceMode.Impulse);
                Destroy(bullet2,5f);
                StartCoroutine(BulletCooldown());
            break;
            
            default:
                GameObject bullet3 = Instantiate(equippedGun.BulletPrefab, gunPoint.transform.position, gunPoint.transform.rotation);
                Rigidbody rb3 = bullet3.GetComponent<Rigidbody>();
                rb3.AddForce(gunPoint.transform.up * equippedGun.BulletSpeed, ForceMode.Impulse);
                Destroy(bullet3,5f);
                StartCoroutine(BulletCooldown());
            break;
        }
    }
    
    //Lance le instantiate
    IEnumerator BulletCooldown()
    {   
        yield return new WaitForSeconds(equippedGun.ShotCooldown);
        canShoot = true;
    }

    //Lance plusieurs fois si automatique et empeche le joueur de spam click
    private IEnumerator BulletDelay()
    {
        canShoot = false;
        
        for(int i = 0; i < equippedGun.FireRate;i++)
        {
           InstantiateBullet(equippedGun.GunName);
           yield return StartCoroutine(BulletTimer()); 
        }
    }

    //Attend entre les balles pour les fusils automatiques
    public IEnumerator BulletTimer()
    {
        float timer = 0.2f;
        
        while(timer>0)
        {
            timer -= Time.deltaTime;
            yield return null;
        }
    }

}


    