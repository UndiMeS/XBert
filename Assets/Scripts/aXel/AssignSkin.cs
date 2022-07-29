using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignSkin : MonoBehaviour
{

    public Animator XBertAnim;
    public List<AnimatorOverrideController> XBertSkin = new List<AnimatorOverrideController>();

    public int SelectedSkin;

    void Awake()
    {
        SelectedSkin = PlayerPrefs.GetInt("SkinNumber");
        XBertAnim.runtimeAnimatorController = XBertSkin[SelectedSkin] as RuntimeAnimatorController;
    }

}
