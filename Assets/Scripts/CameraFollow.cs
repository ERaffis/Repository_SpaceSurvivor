using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [Header ("Components")]
    public Transform cible;
    
    
    [Header("Valeurs")]
    [Range(0,1)] public float vitesseSmooth;
    public Vector3 distance;


    private Vector3 positionSmooth;
    private Vector3 positionFinale;


    // Update is called once per frame
    void Update()
    {
        if(cible)
        {
            CameraLerp();
        }
        
    }

    //Fait en sorte que la caméra suit le joueur
    private void CameraLerp()
    {
        positionFinale = cible.position + distance;
        positionSmooth = Vector3.Lerp(transform.position,positionFinale,vitesseSmooth);
        transform.position = positionSmooth;  
    }

}
