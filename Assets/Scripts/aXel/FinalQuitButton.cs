using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalQuitButton : MonoBehaviour
{
    public bool selected;
    public GameObject QuitButton;
    public GameObject Inventory;
    public AudioClip Choir;
    public AudioClip pocket;
    //AudioSource MayaDiscSound;
    // Start is called before the first frame update


    void Start()
    {
        //MayaDiscSound = this.gameObject.GetComponent<AudioSource>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0)){
                //MayaDiscSound.clip = pocket;
                selected = true;
                //Inventory.SetActive(true);
                StartCoroutine(QuitXBert());
                
        }
    }

    public IEnumerator QuitXBert()
    {
        yield return new WaitForSeconds(1);
        QuitButton.SetActive(true);
                QuitButton.GetComponent<Button>().onClick.Invoke();
                Destroy(this);
    }
}
