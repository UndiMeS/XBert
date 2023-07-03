using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshot : MonoBehaviour
{
    public int count;
    public bool screenshot;
    // Update is called once per frame
    void Update()
    {
        if(screenshot == true)
        {
            if(Input.GetKeyDown("p"))
            {
                ScreenCapture.CaptureScreenshot($"/Users/max/Desktop/screenshot-{count++}.png");
            }
            
        }
        
    }
}
