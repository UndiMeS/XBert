using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SwipeController : MonoBehaviour
{
    public GameObject ScrollBar;
    public GameObject Content;
    public Scrollbar HorizontalBar;
    public float scroll_pos = 0;
    public float [] pos;
    int position;
    public Transform[] children;
    public float barvalue;
    
    // Start is called before the first frame update
    void Start()
    {
         children = new Transform[Content.transform.childCount];
    }

    public void Next()
    {
        if(position < pos.Length - 1)
        {
            position += 1;
            scroll_pos = pos [position];
            SkinManager.selectedSkin = SkinManager.selectedSkin + 1;
        }
    }

    public void Back()
    {
        if(position > 0)
        {
            position -= 1;
            scroll_pos = pos [position];
            SkinManager.selectedSkin = SkinManager.selectedSkin - 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        barvalue = HorizontalBar.value;

        pos = new float[Content.transform.childCount];
        float distance = 1f / (pos.Length - 1);
        for(int i = 0; i < pos.Length; i++)
        {
            pos [i] = distance * i;
            SkinManager.selectedSkin = position;
        }

        if (Input.GetMouseButton(0))
        {
            scroll_pos = HorizontalBar.value;
        }
        else{
            for(int i = 0; i < pos.Length; i++)
            {
                if(scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos [i] - (distance/2))
                {
                    HorizontalBar.value = (Mathf.Lerp (HorizontalBar.value, pos[i], 0.33f));
                    position = i;
                    SkinManager.selectedSkin = position;
                    
                }
            }
        }
        for (int i=0; i<Content.transform.childCount; i++)
        {
            children[i]=Content.transform.GetChild(i);
        }

        LoopList();
    }

    public void LoopList()
    {
        
    }
}
