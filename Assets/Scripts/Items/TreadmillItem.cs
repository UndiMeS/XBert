using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreadmillItem : MonoBehaviour
{

    private GameObject XBert;
    private PlayerMovement XBertMovement;
    public bool Collidet;
    public bool XBertRotating;
    public bool Up;
    public bool Left;
    public bool Right;
    public bool Down;
    public float delay;
    public float RotationTime;
    private Vector3 LeftDirection;
    private Vector3 UpDirection;
    private Vector3 RightDirection;
    private Vector3 DownDirection;
    public Vector3 TreadmillDirection;
    public bool StopTreadmill;
    private GameObject[] Treadmills;
    private float XBertSpeed;
    //public TreadmillItem[] OtherTreadmills;
    // Start is called before the first frame update
    void Start()
    {

        

        XBert = GameObject.FindGameObjectWithTag("Axel");
        XBertMovement = XBert.GetComponent<PlayerMovement>();


        Treadmills = GameObject.FindGameObjectsWithTag("Treadmill");


        LeftDirection = new Vector3 (-XBertMovement.step, 0.0f, 0.0f);
        UpDirection = new Vector3 (0.0f, XBertMovement.step, 0.0f);
        RightDirection = new Vector3 (XBertMovement.step, 0.0f, 0.0f);
        DownDirection = new Vector3 (0.0f, -XBertMovement.step, 0.0f);

        //RotationTime = RotationTime * Time.deltaTime;
        XBertSpeed = XBertMovement.moveSpeed;

        
    }

    // Update is called once per frame
    void Update()
    {
        if(Collidet == true)
        {
            PlayerMovement.moving = false;
            foreach (GameObject Treadmill in Treadmills)
            {
                if(Treadmill.Equals(this.gameObject))
                continue;
                if(Vector3.Distance(Treadmill.transform.position, XBertMovement.movePoint.position) < 0.1f)
                {
                    PlayerMovement.moving = false;
                    StopTreadmill = true;
                }

                
            }

            

            XBertRotating = true;
            if(! Physics2D.OverlapCircle(XBertMovement.movePoint.position + TreadmillDirection, .2f, XBertMovement.whatStopsMovement)&&! Physics2D.OverlapCircle(XBertMovement.movePoint.position + TreadmillDirection, .2f, XBertMovement.BreakingWall) && StopTreadmill == false)
            {
                PlayerMovement.moving = false;
                XBertMovement.movePoint.position += TreadmillDirection;
                
            }
            else
            {
                PlayerMovement.moving = false;
                Collidet = false;
            }
        }

        if(XBertRotating == true)
        {
            PlayerMovement.moving = false;
            if(Vector3.Distance(XBert.transform.position, XBertMovement.movePoint.position) > 0.01f)
        //if(Physics2D.OverlapCircle(XBert.transform.position + new Vector3 (-XBertMovement.step,0.0f, 0.0f), .2f, XBertMovement.whatStopsMovement)||Physics2D.OverlapCircle(XBert.transform.position + new Vector3 (-XBertMovement.step,0.0f, 0.0f), .2f, XBertMovement.BreakingWall))
        {
            XBertMovement.moveSpeed = 5;
            XBert.transform.Rotate(new Vector3( 0, 0, 90) * RotationTime);
        }
        else
        {
            StartCoroutine(TreadmillStop());
        }
        }
        
    }

    IEnumerator StartTreatmill()
    {
        PlayerMovement.moving = false;
        yield return new WaitForSeconds(delay);
        
        Collidet = true;
    }
    IEnumerator TreadmillStop()
    {
        PlayerMovement.moving = false;
        yield return new WaitForSeconds(delay);
        XBertMovement.moveSpeed = XBertSpeed;
            PlayerMovement.moving = true;
            XBertRotating = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        

        StopTreadmill = false;
        
        if(col.gameObject.tag == "Axel" && Collidet == false)
        {
            PlayerMovement.moving = false;
            if(Left == true)
            {
                TreadmillDirection = LeftDirection;
                
            }
            if(Up == true)
            {
                TreadmillDirection = UpDirection;
            }
            if(Right == true)
            {
                TreadmillDirection = RightDirection;
            }
            if(Down == true)
            {
                TreadmillDirection = DownDirection;
            }
            
                StartCoroutine(StartTreatmill());
            
        }
       

        
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag == "Axel")
        {
            PlayerMovement.moving = false;
        }
    }
}
