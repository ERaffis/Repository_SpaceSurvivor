using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class qui gère les sons
public class SoundManagerScript : MonoBehaviour
{

    public static AudioClip laserSound, laserBigSound, laserBombSound, deathMusic, triggerSound, useItemSound;
    public static AudioSource audioSrc;


    // Start is called before the first frame update
    void Start()
    {
        laserSound = Resources.Load<AudioClip>("laser");
        laserBigSound = Resources.Load<AudioClip>("laserBig");
        laserBombSound = Resources.Load<AudioClip>("laserBomb");
        deathMusic = Resources.Load<AudioClip>("deathJingle");
        triggerSound = Resources.Load<AudioClip>("trigger");
        useItemSound = Resources.Load<AudioClip>("useitem"); 
        audioSrc = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "laser":
                audioSrc.PlayOneShot(laserSound);
            break;
            case "trigger":
                audioSrc.PlayOneShot(triggerSound);
                break;
            case "useitem":
                audioSrc.PlayOneShot(useItemSound);
                break;
            case "deathJingle":
                audioSrc.PlayOneShot(deathMusic);
            break;
        }
    }


}
