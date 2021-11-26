using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwitch : MonoBehaviour
{
    public GameObject[] SubAddZones;
    // Start is called before the first frame update
    void Start()
    {
        
            SubAddZones = GameObject.FindGameObjectsWithTag("SubAddZone");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Axel")
        {
            
            foreach(GameObject SubAddZone in SubAddZones)
            {
                SubAddZone.GetComponent<SubAddZone>().Subtract = !SubAddZone.GetComponent<SubAddZone>().Subtract;
            }
            Destroy(this.gameObject);
        }
    }
}
