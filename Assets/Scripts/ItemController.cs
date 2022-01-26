using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Objet qui gère les objets
public class ItemController : MonoBehaviour
{
    public Image cursor1;
    public Image cursor2;
    public GameObject player;

    public int consNum1;
    public int consNum2;
    public TMP_Text consNumText1;
    public TMP_Text consNumText2;

    private GameObject[] listOfEnemies;
    public GameObject[] listOfConsumables = new GameObject[2];


    // Start is called before the first frame update
    void Start()
    {
        consNum1 = 0;
        consNum2 = 0;

        cursor1.enabled = true;
        cursor2.enabled = false;

        consNumText1.SetText(consNum1.ToString());
        consNumText2.SetText(consNum2.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        ChangeSelectedItem();
        

        if(Input.GetKeyDown(KeyCode.LeftAlt) || Input.GetMouseButtonDown(1))
        {
            UseSelectedItem();
        }

        
    }

    private void FixedUpdate() {
        SpawnItem();
    }

    //Fonction pour changer l'object actif
    void ChangeSelectedItem()
    {
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            cursor1.enabled = !cursor1.enabled;
            cursor2.enabled = !cursor2.enabled;
        }
    }

    //Fonction pour utiliser les objets
    void UseSelectedItem()
    {
        if(cursor1.enabled)
        {
            if(consNum1 != 0)
            {
                player.GetComponent<StateManager>().health += 50;
                if(player.GetComponent<StateManager>().health > 250) player.GetComponent<StateManager>().health = 250; 
                player.GetComponent<StateManager>().healthBar.value = player.GetComponent<StateManager>().health;
                consNum1 --;
                consNumText1.SetText(consNum1.ToString());
                SoundManagerScript.PlaySound("trigger");
            }
        } else
        {
            if(consNum2 != 0)
            {
                
                listOfEnemies = GameObject.FindGameObjectsWithTag("Enemy");
                foreach (GameObject enemy in listOfEnemies)
                {
                    Destroy(enemy);
                }
                consNum2 --;
                consNumText2.SetText(consNum2.ToString());
                SoundManagerScript.PlaySound("trigger");
            }
        }
    }
    
    //Fonction qui modifie le nombre lorsqu'on pickup un objet
    public void PickUpItem(int i)
    {
        if (i == 0)
        {
            consNum1 ++;
            consNumText1.SetText(consNum1.ToString());
        }

        if (i == 1)
        {
            consNum2 ++;
            consNumText2.SetText(consNum2.ToString());
        }
    }

    //Fonction qui fait spawner les items
    public void SpawnItem()
    {
        if(Random.Range(0,750) < 5)
        {
            print("ding");
            int value = Random.Range(0,3);

            switch (value)
            {
                    
            case 0:
                GameObject newItem = Instantiate(
                listOfConsumables[Random.Range(0,2)], 
                new Vector3(
                player.transform.position.x + Random.Range(40,20), 
                player.transform.position.y + Random.Range(40,20),
                0 ), 
                Quaternion.Euler(0, 0, 0));
                
            break;

            case 1:
                GameObject newItem1 = Instantiate(
                listOfConsumables[Random.Range(0,2)], 
                new Vector3(
                player.transform.position.x - Random.Range(40,20), 
                player.transform.position.y + Random.Range(40,20),
                0 ), 
                Quaternion.Euler(0, 0, 0));
            
            break;
            
            case 2:
                GameObject newItem2 = Instantiate(
                listOfConsumables[Random.Range(0,2)], 
                new Vector3(
                player.transform.position.x + Random.Range(40,20), 
                player.transform.position.y - Random.Range(40,20),
                0 ), 
                Quaternion.Euler(0, 0, 0));
            
            break;
            
            case 3:
                GameObject newItem3 = Instantiate(
                listOfConsumables[Random.Range(0,2)], 
                new Vector3(
                player.transform.position.x - Random.Range(40,20), 
                player.transform.position.y - Random.Range(40,20),
                0 ), 
                Quaternion.Euler(0, 0, 0));
            
            break;
            
            }
        }
    }
}
