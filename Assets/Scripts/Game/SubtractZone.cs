using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubtractZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
{
    if(col.gameObject.tag == "Numbers")
    {
        col.gameObject.GetComponent<aXelNumber>().Subtract = true;
        Debug.Log("enter");
    }
}

    void OnTriggerStay2D(Collider2D col)
{
    if(col.gameObject.tag == "Numbers")
    {
        col.gameObject.GetComponent<aXelNumber>().Subtract = true;
        Debug.Log("enter");
    }
}
}
