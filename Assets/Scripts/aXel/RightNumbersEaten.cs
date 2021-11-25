using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightNumbersEaten : MonoBehaviour
{
     public bool loaded;
    // Start is called before the first frame update
    void Start()
    {
        loaded = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "aXelNumberRight")
        {
            loaded = true;
        }
        
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag == "aXelNumberRight")
        {
            loaded = true;
        }
    }
}

