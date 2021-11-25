using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberCount : MonoBehaviour
{

    public int CountedNumbers;
    public GameObject Solution;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CountedNumbers = Solution.GetComponent<SolutionNumbers>().EatenNumberCounter;

        this.GetComponent<TMP_Text>().text = CountedNumbers.ToString();
    }
}
