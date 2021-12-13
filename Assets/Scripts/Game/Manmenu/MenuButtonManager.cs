using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonManager : MonoBehaviour
{

    public GameObject StartMenu;
    public GameObject WorldOne;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToStartMenu()
    {
        StartMenu.SetActive(true);
        WorldOne.SetActive(false);
    }


    public void ToWorldOne()
    {
        StartMenu.SetActive(false);
        WorldOne.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
