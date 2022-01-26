using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Class pour les fusils orienté objet
public class Gun 
{
    public string GunName { get; set; }
    public int GunDamage { get; set; }
    public GameObject BulletPrefab { get; set; }
    public float BulletSpeed { get; set; }
    public int ClipSize { get; set; }
    public int FireRate { get; set; }
    public int MaxAmmo { get; set; }
    public float ShotCooldown { get; set; }


    public Gun()
    {
        this.GunName = "";
        this.GunDamage = 0;
        this.BulletPrefab = null;
        this.BulletSpeed = 0f;
        this.ClipSize = 0;
        this.FireRate = 0;
        this.MaxAmmo = 0;
        this.ShotCooldown = 0;

    }

    public Gun(string gunName, int gunDamage, GameObject bulletPrefab, float bulletSpeed, int fireRate, float shotCooldown)
    {
        this.GunName = gunName;
        this.GunDamage = gunDamage;
        this.BulletPrefab = bulletPrefab;
        this.BulletSpeed = bulletSpeed;
        this.FireRate = fireRate;
        this.ShotCooldown = shotCooldown;
        

    }

    public static Dictionary<string, Gun> GunDictionary = new Dictionary<string, Gun>()
    {                       //Name              Dmg         bulletpreFab                                                                bulletSpeed     FireRate        Cooldown
        {"Laser", new Gun("Laser",              35,         GameObject.Find("Player").GetComponent<BulletPrefabs>().laserPrefab,        50f,            1,              0.25f)},
        {"Bomb",  new Gun("Bomb",               50,         GameObject.Find("Player").GetComponent<BulletPrefabs>().bombPrefab,         10f,            1,              2.5f)},
        {"Big Laser", new Gun("Big Laser",      100,        GameObject.Find("Player").GetComponent<BulletPrefabs>().bigLaserPrefab,     75f,            1,              1f)},
        {"Flak Cannon", new Gun("Flak Cannon",  25,         GameObject.Find("Player").GetComponent<BulletPrefabs>().flakCannonPrefab,   25f,            1,              0.75f)},
        {"Beam", new Gun("Beam",                100,        GameObject.Find("Player").GetComponent<BulletPrefabs>().beamPrefab,         15f,           1,              5f)}
    };
}

