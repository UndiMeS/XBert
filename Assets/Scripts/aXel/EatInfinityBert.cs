using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatInfinityBert : MonoBehaviour
{

    public Animator animator;
    public OutroManager OutroSkript;
    public GameObject ScreenFive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if(col.transform.gameObject.name =="aXel")
        {
            animator.SetTrigger("EatTrigger");
        }

    }


    public IEnumerator EatingInfinity()
    {
        yield return new WaitForSeconds(0.1f);
    }
}
