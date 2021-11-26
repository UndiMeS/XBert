using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubAddZone : MonoBehaviour
{

public Color SubtractColor;
public UnityEngine.U2D.SpriteShapeRenderer ZoneRenderer;
public Color AdditionColor;
    public bool Subtract;
    // Start is called before the first frame update
    void Start()
    {
        ZoneRenderer = this.gameObject.GetComponent<UnityEngine.U2D.SpriteShapeRenderer>();
        if(this.gameObject.name == "SubtractZone")
        {
            Subtract = true;
            ZoneRenderer.color = SubtractColor;
        }
        else
        {
            Subtract = false;
            ZoneRenderer.color = AdditionColor;
        }
    }

    // Update is called once per frame
    void Update()
    {
         if(Subtract == true)
        {
            //col.gameObject.GetComponent<aXelNumber>().Subtract = true;
            ZoneRenderer.color = SubtractColor;
        //Debug.Log("enter");
        }
        if(Subtract == false)
        {
            //col.gameObject.GetComponent<aXelNumber>().Subtract = false;
            ZoneRenderer.color = AdditionColor;
        //Debug.Log("enter");
        }
    }

    void OnTriggerEnter2D(Collider2D col)
{
    if(col.gameObject.tag == "Numbers")
    {
        if(ZoneRenderer.color == SubtractColor)
        {
            col.gameObject.GetComponent<aXelNumber>().Subtract = true;
            //ZoneRenderer.color = SubtractColor;
        //Debug.Log("enter");
        }
        if(ZoneRenderer.color == AdditionColor)
        {
            col.gameObject.GetComponent<aXelNumber>().Subtract = false;
            //ZoneRenderer.color = AdditionColor;
        //Debug.Log("enter");
        }
        
    }
}

    void OnTriggerStay2D(Collider2D col)
{
    if(col.gameObject.tag == "Numbers")
    {
        if(ZoneRenderer.color == SubtractColor)
        {
            col.gameObject.GetComponent<aXelNumber>().Subtract = true;
            //ZoneRenderer.color = SubtractColor;
        }
        if(ZoneRenderer.color == AdditionColor)
        {
            col.gameObject.GetComponent<aXelNumber>().Subtract = false;
            //ZoneRenderer.color = AdditionColor;
        //Debug.Log("enter");
        }
        
        //Debug.Log("enter");
    }
}

    void OnTriggerExit2D(Collider2D col)
{
    if(col.gameObject.tag == "Numbers")
    {
        if(ZoneRenderer.color == SubtractColor)
        {
            col.gameObject.GetComponent<aXelNumber>().Subtract = false;
            //ZoneRenderer.color = AdditionColor;
        }
        if(ZoneRenderer.color == AdditionColor)
        {
            col.gameObject.GetComponent<aXelNumber>().Subtract = true;
            //ZoneRenderer.color = SubtractColor;
        //Debug.Log("enter");
        }
        
        //Debug.Log("enter");
    }
}
}
