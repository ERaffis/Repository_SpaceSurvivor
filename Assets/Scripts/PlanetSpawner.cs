using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Fait spawner le planètes au début de la partie
public class PlanetSpawner : MonoBehaviour
{
    public GameObject[] planetArray = new GameObject[5];

    private void Start() 
    {
        for (int i = 0; i < 500; i += 5)
        {
            int value = Random.Range(0,4);

        switch (value)
            {
                    
            case 0:
                GameObject newPlanet = Instantiate(
                planetArray[Random.Range(0,4)], 
                new Vector3(
                Random.Range(-5,5) * i, 
                Random.Range(-5,5) * i,
                0 ), 
                Quaternion.Euler(0, 0, 0));

                float scale = Random.Range(0.5f,10);
                newPlanet.transform.localScale.Scale(new Vector3 (scale,scale,scale));
                
            break;

            case 1:
                GameObject newPlanet1 = Instantiate(
                planetArray[Random.Range(0,4)], 
                new Vector3(
                Random.Range(-5,5) * i, 
                Random.Range(-5,5) * i,
                0 ), 
                Quaternion.Euler(0, 0, 0));

                float scale1 = Random.Range(0.5f,10);
                newPlanet1.transform.localScale.Scale(new Vector3 (scale1,scale1,scale1));
            
            break;
            
            case 2:
                GameObject newPlanet2 = Instantiate(
                planetArray[Random.Range(0,4)], 
                new Vector3(
                Random.Range(-5,5) * i, 
                Random.Range(-5,5) * i,
                0 ), 
                Quaternion.Euler(0, 0, 0));

                float scale2 = Random.Range(0.5f,10);
                newPlanet2.transform.localScale.Scale(new Vector3 (scale2,scale2,scale2));
            
            break;
            
            case 3:
                GameObject newPlanet3 = Instantiate(
                planetArray[Random.Range(0,4)], 
                new Vector3(
                Random.Range(-5,5) * i, 
                Random.Range(-5,5) * i,
                0 ), 
                Quaternion.Euler(0, 0, 0));

                float scale3 = Random.Range(0.5f,10);
                newPlanet3.transform.localScale.Scale(new Vector3 (scale3,scale3,scale3));
            
            break;

            case 4:
                GameObject newPlanet4 = Instantiate(
                planetArray[Random.Range(0,4)], 
                new Vector3(
                Random.Range(-5,5) * i, 
                Random.Range(-5,5) * i,
                0 ), 
                Quaternion.Euler(0, 0, 0));
            
                float scale4 = Random.Range(0.5f,10);
                newPlanet4.transform.localScale.Scale(new Vector3 (scale4,scale4,scale4));

            break;
        }    
    }
    }
}
