using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{

    public GameObject OtherPortal;

    public GameObject Axel;
    public GameObject AxelMovement;
    public bool teleport = false;

    Vector3 maxScale;
    public Vector3 minScale;
    public bool repeatable;
    public float speed = 2f;
    public float duration = 5f;
    public bool TeleportStart = true;

    public
    // Start is called before the first frame update
    void Start()
    {
        teleport = false;
    }

    // Update is called once per frame
    void Update()
    {

        //If this Portal is teleporting
        if(teleport == true)
        {

            //if Axel is Originial Size and telportation is starting start Coroutine
            if(Axel.transform.localScale == maxScale && TeleportStart == true)
            {
                

                StartCoroutine(DownScale(maxScale, minScale, duration));
                
            }
            

            //if Axel is minScale change Position to other Portal and make it big again
            if(Axel.transform.localScale == minScale && TeleportStart == true)
            {
                TeleportStart = false;
                OtherPortal.GetComponent<Portal>().TeleportStart = false;
                Axel.transform.position = OtherPortal.transform.position;
                AxelMovement.transform.position = OtherPortal.transform.position;
                teleport = false;
                StartCoroutine(DownScale(minScale, maxScale, duration));
                Debug.Log("Arrived");    
            }            
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //if Axel ist on portal start teleporting
        if(col.tag == "Axel" && TeleportStart == true)
        {
            
            teleport = true;

            Axel = col.gameObject;

            maxScale = Axel.transform.localScale;
            PlayerMovement.moving = false;
            Debug.Log("Teleport");
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        //if Axel left portal change the teleport bools
        if(col.tag == "Axel")
        {
            TeleportStart = true;
            teleport = false;

        }
    }

// Coroutne to change Axel Scale and Rotation -> teleport Animation
    public IEnumerator DownScale(Vector3 a, Vector3 b, float time)
    {
        float i = 0.0f;
        float rate = (1.0f / time) * speed;

        while (i < 1.0f) {
            i+= Time.deltaTime * rate;
            Axel.transform.localScale = Vector3.Lerp(a,b, i);
            
            Axel.transform.Rotate(new Vector3(0f,0f, 200f)* Time.deltaTime);
            
            yield return null;
        }


        if(Axel.transform.localScale == maxScale)
            {
                PlayerMovement.moving = true;
                TeleportStart = true;
            }
    }
}
