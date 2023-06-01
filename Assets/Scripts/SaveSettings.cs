using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveSettings : MonoBehaviour
{
    public Animator MenuAnimator;
    public Slider VolumeSlider;
    public Slider FieldOfViewSlider;
    public string Difficulty { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUpSettings() =>
        MenuAnimator.Play($"Select {Difficulty = PlayerPrefs.GetString("Difficulty")}");

    public void SaveSettingsOnClose()
    {
        PlayerPrefs.SetFloat("Volume", VolumeSlider.value);
        PlayerPrefs.SetFloat("Field Of View", FieldOfViewSlider.value);
        PlayerPrefs.SetString("Difficulty", Difficulty);
    }
}
