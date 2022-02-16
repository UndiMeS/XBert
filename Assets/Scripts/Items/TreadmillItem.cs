using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreadmillItem : MonoBehaviour
{

    public GameObject XBert;
    public PlayerMovement XBertMovement;
    public bool Collidet;
    public bool XBertRotating;
    public bool Up;
    public bool Left;
    public bool Right;
    public bool Down;
    public float delay;
    public float RotationTime;
    public Vector3 LeftDirection;
    public Vector3 UpDirection;
    public Vector3 RightDirection;
    public Vector3 DownDirection;
    public Vector3 TreadmillDirection;
    public LayerMask TreadmillLayer;
    public bool StopTreadmill;
    public TreadmillItem[] OtherTreadmills;
    // Start is called before the first frame update
    void Start()
    {
        LeftDirection = new Vector3 (-XBertMovement.step, 0.0f, 0.0f);
        UpDirection = new Vector3 (0.0f, XBertMovement.step, 0.0f);
        RightDirection = new Vector3 (XBertMovement.step, 0.0f, 0.0f);
        DownDirection = new Vector3 (0.0f, -XBertMovement.step, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Collidet == true)
        {

            foreach (TreadmillItem OtherTreadmill in OtherTreadmills)
            {
                if(Vector3.Distance(OtherTreadmill.transform.position, XBertMovement.movePoint.position) < 0.05f)
                {
                    StopTreadmill = true;
                }

                
            }

            

            XBertRotating = true;
            if(! Physics2D.OverlapCircle(XBertMovement.movePoint.position + TreadmillDirection, .2f, XBertMovement.whatStopsMovement)&&! Physics2D.OverlapCircle(XBertMovement.movePoint.position + TreadmillDirection, .2f, XBertMovement.BreakingWall) && StopTreadmill == false)
            {

                // if(Physics2D.OverlapCircle(XBertMovement.movePoint.position, .2f, TreadmillLayer))
                // {
                //     Collidet = false;
                //     //return;
                // }
                
                XBertMovement.movePoint.position += TreadmillDirection;
                
            }
            else
            {
                //XBertMovement.moveSpeed = 20;
                Collidet = false;
            }
        }

        if(XBertRotating == true)
        {
            if(Vector3.Distance(XBert.transform.position, XBertMovement.movePoint.position) > 0.1f)
        //if(Physics2D.OverlapCircle(XBert.transform.position + new Vector3 (-XBertMovement.step,0.0f, 0.0f), .2f, XBertMovement.whatStopsMovement)||Physics2D.OverlapCircle(XBert.transform.position + new Vector3 (-XBertMovement.step,0.0f, 0.0f), .2f, XBertMovement.BreakingWall))
        {
            XBertMovement.moveSpeed = 5;
            XBert.transform.Rotate(new Vector3( 0, 0, 90) * RotationTime * Time.deltaTime);
        }
        else
        {
            XBertMovement.moveSpeed = 20;
            PlayerMovement.moving = true;
            XBertRotating = false;
        }
        }
        
    }

    IEnumerator StartTreatmill()
    {
        PlayerMovement.moving = false;
        yield return new WaitForSeconds(delay);
        
        Collidet = true;
                
        
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        StopTreadmill = false;
        
        if(col.gameObject.tag == "Axel" && Collidet == false)
        {
            
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
        // else if(col.gameObject.tag == "Axel" && Collidet == true)
        // {
        //     foreach (TreadmillItem OtherTreadmill in OtherTreadmills)
        //     {
        //         OtherTreadmill.Collidet = false;
        //     }
            
        // }

        
    }
}
