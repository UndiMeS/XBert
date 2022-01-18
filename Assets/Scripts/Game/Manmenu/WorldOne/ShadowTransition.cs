using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowTransition : MonoBehaviour
{
    public LevelLoader lvlLoader;
    public Animator ShadowAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShadowLoader()
    {
        lvlLoader.LoadScene = "";
        lvlLoader.transition = ShadowAnimator;
    }
}
