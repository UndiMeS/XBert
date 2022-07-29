using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SkinManager : MonoBehaviour
{
    public Animator XBertAnim;
    public List<AnimatorOverrideController> XBertSkin = new List<AnimatorOverrideController>();
    public int selectedSkin = 0;
    public GameObject PlayerSkin;


    public void Awake()
    {
        XBertAnim.runtimeAnimatorController = XBertSkin[0] as RuntimeAnimatorController;
    }


    public void NextOption()
    {
        selectedSkin = selectedSkin + 1;
        if(selectedSkin == XBertSkin.Count)
        {
            selectedSkin = 0;
        }
        //XBertAnim.runtimeAnimatorController = XBertSkin[selectedSkin] as RuntimeAnimatorController;
    }


    public void BackOption()
    {
        selectedSkin = selectedSkin - 1;
        if(selectedSkin < 0)
        {
            selectedSkin = XBertSkin.Count - 1;
        }
        //XBertAnim.runtimeAnimatorController = XBertSkin[selectedSkin] as RuntimeAnimatorController;
    }

    public void ChooseSkin()
    {
        //PrefabUtility.SaveAsPrefabAsset(PlayerSkin, "Assets/Prefab/aXel.prefab");
        PlayerPrefs.SetInt("SkinNumber", selectedSkin);
    }



}
