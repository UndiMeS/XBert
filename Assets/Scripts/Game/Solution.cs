using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Solution : MonoBehaviour
{

    public float NumbersSolution;
    public int EatenNumberCounter;
    public GameObject ZeroLeft;
    public GameObject ZeroRight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<TMP_Text>().text = NumbersSolution.ToString();

        if(NumbersSolution != 0)
        {
            ZeroLeft.SetActive(false);
            ZeroRight.SetActive(false);
        }
    }
}
