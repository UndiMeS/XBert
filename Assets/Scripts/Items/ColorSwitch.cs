using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwitch : MonoBehaviour
{
    public GameObject[] SubAddZones;
    public GameObject[] Numbers;
    // Start is called before the first frame update
    void Start()
    {
        
            SubAddZones = GameObject.FindGameObjectsWithTag("SubAddZone");

            Numbers = GameObject.FindGameObjectsWithTag("Numbers");
        
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

            foreach (GameObject Number in Numbers)
            {
                Number.GetComponent<aXelNumber>().Subtract = !Number.GetComponent<aXelNumber>().Subtract;
            }
            Destroy(this.gameObject);
        }
    }
}
