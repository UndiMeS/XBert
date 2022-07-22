using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public class SetVolume : MonoBehaviour
{
    public AudioMixer EffektMixer;
    public AudioMixer MusikMixer;
    public Slider EffektSlider;
    public Slider MusikSlider;

    void Start()
    {
        MusikSlider.value = PlayerPrefs.GetFloat("MusikVolume", 0.000f);
        EffektSlider.value = PlayerPrefs.GetFloat("EffektVolume", 0.000f);

        EffektMixer.SetFloat ("EffektVol", Mathf.Log10(EffektSlider.value)*20);
        MusikMixer.SetFloat ("MusikVol", Mathf.Log10(MusikSlider.value)*20);
    }



    public void SetEffektLevel(float EffektSliderValue)
    {
        EffektMixer.SetFloat ("EffektVol", Mathf.Log10(EffektSliderValue)* 20 );
        PlayerPrefs.SetFloat("EffektVolume", EffektSliderValue);
    }

    public void SetMusikLevel(float MusikSliderValue)
    {
        MusikMixer.SetFloat ("MusikVol", Mathf.Log10(MusikSliderValue)* 20 );
        PlayerPrefs.SetFloat("MusikVolume", MusikSliderValue);
    }
   
}
