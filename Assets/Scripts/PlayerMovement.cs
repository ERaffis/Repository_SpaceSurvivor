using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header ("Horizontal Movement")]
    [Range(0,100)] public float speed;
    [Range(0,100)] public float dashSpeed;


    [Header("System Values")]
    public Vector2 moveInput;
    public bool shouldFollow;
    public bool canDash;
    private Vector3 mousePosition;
    private Vector3 lookDir;

    [Header("Components")]
    public Rigidbody rb;
    public Camera cam;
    public Vector3 screenBounds;
    public GameObject gunPoint;


    private void Awake() {
        Application.targetFrameRate = 60;
    }

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = cam.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,cam.transform.position.z));
        shouldFollow = true;
        canDash = true;
    }   

    // Update is called once per frame
    void Update()
    {   
        CheckVelocity();
        if(Input.GetKeyDown(KeyCode.LeftShift) && canDash == true) 
        {
            StartCoroutine(Dash());
        }
    }


    void FixedUpdate() 
    {
        PlayerFaceMouse();        
        PlayerMove();
    }

    //Fait avancer le joueur vers la souris
    void PlayerMove()
    {   
        rb.AddForce(lookDir*speed);
    }

    //Fait en sorte que le joueur regarde toujours la souris
    void PlayerFaceMouse()
    {
        mousePosition = new Vector3(Input.mousePosition.x,Input.mousePosition.y,0);
        lookDir = cam.ScreenToWorldPoint(mousePosition);
        lookDir = lookDir - transform.position;

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg -90f;
        rb.rotation = Quaternion.AngleAxis(angle,Vector3.forward);
        
    }

    //S'assure que le vaisseau va pas trop vite
    private void CheckVelocity()
    {
        if(rb.velocity.x > 10)
        {
            rb.velocity = new Vector3 (10, rb.velocity.y,0);
        }
        if(rb.velocity.y> 10)
        {
            rb.velocity = new Vector3 (rb.velocity.x, 10,0);
        }
    }

    //Dash invincible
    IEnumerator Dash()
    {
        print("Dash");
        canDash = false;
        rb.AddForce(lookDir * dashSpeed, ForceMode.Impulse);

        GetComponent<Collider>().enabled = false;
        GetComponent<SpriteRenderer>().color = Color.gray;

        yield return new WaitForSeconds(1f);

        GetComponent<Collider>().enabled = true;
        GetComponent<SpriteRenderer>().color = Color.white;

        yield return new WaitForSeconds(1f);
        canDash = true;
    }

}
