using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Fait spawner des ennemis aléatoirement
public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject playerCible;
    private float difficulty;
    private float timeUntlSpwanRateIncrease = 20;


    private void Start() 
    {
        playerCible = GameObject.Find("Player");
        difficulty = 1f;
    }
    

    private void FixedUpdate() 
    {
        if(playerCible)
        {
            InstantiateEnnemy(Random.Range(0,1200));
        }
        timeUntlSpwanRateIncrease -= Time.deltaTime;
        ChangeDifficulty();
    }

    //Instantiate un ennemi aléatoirement, augmente selon le temps
    public void InstantiateEnnemy(int num)
    {

        if(num * difficulty <= 5  )
        {
            int value = Random.Range(0,3);

            switch (value)
            {
                    
            case 0:
                GameObject newEnnemy = Instantiate(
                enemyPrefab, 
                new Vector3(
                playerCible.transform.position.x + Random.Range(40,20), 
                playerCible.transform.position.y + Random.Range(40,20),
                0 ), 
                Quaternion.Euler(0, 0, 0));
                
            break;

            case 1:
                GameObject newEnnemy1 = Instantiate(
                enemyPrefab, 
                new Vector3(
                playerCible.transform.position.x - Random.Range(40,20), 
                playerCible.transform.position.y + Random.Range(40,20),
                0 ), 
                Quaternion.Euler(0, 0, 0));
            
            break;
            
            case 2:
                GameObject newEnnemy2 = Instantiate(
                enemyPrefab, 
                new Vector3(
                playerCible.transform.position.x + Random.Range(40,20), 
                playerCible.transform.position.y - Random.Range(40,20),
                0 ), 
                Quaternion.Euler(0, 0, 0));
            
            break;
            
            case 3:
                GameObject newEnnemy3 = Instantiate(
                enemyPrefab, 
                new Vector3(
                playerCible.transform.position.x - Random.Range(40,20), 
                playerCible.transform.position.y - Random.Range(40,20),
                0 ), 
                Quaternion.Euler(0, 0, 0));
            
            break;
            
            }
            
        }
    }
    
    //Modifie la difficulté selon le temps
    public void ChangeDifficulty()
    {
        if(timeUntlSpwanRateIncrease <= 0)
        {
            difficulty -= 0.05f;
            timeUntlSpwanRateIncrease = 20;
        }
    }
}
