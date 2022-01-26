using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Radar qui détecte les items
public class RadarPulse : MonoBehaviour
{

    [SerializeField] private Transform radarPingPrefab;

    private Transform pulseTransform;
    private float range;
    private float rangeMax;
    private float fadeRange;

    private SpriteRenderer pulseSpriteRenderer;
    private Color pulseColor;

    private GameObject player;
    private List<Collider> alreadyPingedList;

    private void Awake() {
        pulseTransform = transform.Find("Pulse");
        player = GameObject.Find("Player");

        pulseSpriteRenderer = pulseTransform.GetComponent<SpriteRenderer>();
        pulseColor = pulseSpriteRenderer.color;
        rangeMax = 50f;
        fadeRange = 15f;

        alreadyPingedList = new List<Collider>();
    }

    private void Update() {
        //Fait grossir le scan et supprime quand arrive à limite
        float rangeSpeed = 25f;
        range += rangeSpeed * Time.deltaTime;
        if(range > rangeMax)
        {
            range = 0f;
            alreadyPingedList.Clear();
        }

        
        pulseTransform.localScale = new Vector3(range,range);

        //Raycast pour trouver tous les items et placer dans un array
        RaycastHit[] hitArray  = Physics.SphereCastAll(transform.position, range/2, Vector3.up,50);      
        foreach (RaycastHit hit in hitArray)
        {
            if(hit.collider != null)
            {
                if(!alreadyPingedList.Contains(hit.collider) && (hit.collider.gameObject.tag == "Item1" || hit.collider.gameObject.tag == "Item2"))
                {
                    Transform radarPingTransform = Instantiate(radarPingPrefab, hit.point, Quaternion.identity);
                    
                    alreadyPingedList.Add(hit.collider);

                    if(hit.collider.gameObject.tag == "Item1")
                    {
                        radarPingTransform.GetComponent<RadarPing>().SetColor(Color.red);
                        radarPingTransform.gameObject.layer = 9;
                    }

                    if(hit.collider.gameObject.tag == "Item2" )
                    {
                        radarPingTransform.GetComponent<RadarPing>().SetColor(Color.cyan);
                        radarPingTransform.gameObject.layer = 9;
                    }

                    radarPingTransform.GetComponent<RadarPing>().SetDisappearTimer(rangeMax / rangeSpeed);
                }
                
            }
        }
        
        //Fait fader le scan à la fin
        if(range > rangeMax - fadeRange)
        {
            pulseColor.a = Mathf.Lerp(0f,1f, (rangeMax- range) / fadeRange);
        } else {
            pulseColor.a = 1f;
        }
        pulseSpriteRenderer.color = pulseColor;
    }
}
