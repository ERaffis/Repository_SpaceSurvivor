using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTriggerController : MonoBehaviour
{

    public GameObject itemObject;
    
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Item1")
        {
            itemObject.GetComponent<ItemController>().PickUpItem(0);
            Destroy(other.gameObject);
            SoundManagerScript.PlaySound("useitem");
        }

        if (other.gameObject.tag == "Item2")
        {
            itemObject.GetComponent<ItemController>().PickUpItem(1);
            Destroy(other.gameObject);
            SoundManagerScript.PlaySound("useitem");
        }
    }
}
