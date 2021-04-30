using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer volMixer;

    public Slider volSlider;

    public Dropdown qualityDropDown;

    public Dropdown resolutionDropDown;

    public Toggle fullScreenToggle;

    private int screenInt;

    Resolution[] resolutions;

    private bool isFullScreen = false;

    const string preName = "settingvalue";
    const string resName = "resolutionoption";

    private void Awake()
    {
        screenInt = PlayerPrefs.GetInt("togglestate");

        if(screenInt == 1)
        {
            isFullScreen = true;
            fullScreenToggle.isOn = true;
        }
        else
        {
            fullScreenToggle.isOn = false;
        }

        resolutionDropDown.onValueChanged.AddListener(new UnityAction<int>(index =>
        {
            PlayerPrefs.SetInt(resName, resolutionDropDown.value);
            PlayerPrefs.Save();
        }));
        qualityDropDown.onValueChanged.AddListener(new UnityAction<int>(index =>
        {
            PlayerPrefs.SetInt(preName, qualityDropDown.value);
            PlayerPrefs.Save();
        }));
    }

    void Start()
    {
        volSlider.value = PlayerPrefs.GetFloat("MVolume", 1f);
        volMixer.SetFloat("SfxVol", PlayerPrefs.GetFloat("MVolume"));

        qualityDropDown.value = PlayerPrefs.GetInt(preName, 3);

        resolutions = Screen.resolutions;

        resolutionDropDown.ClearOptions();


        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height + " " + resolutions[i].refreshRate + "Hz";
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width &&
               resolutions[i].height == Screen.currentResolution.height &&
               resolutions[i].refreshRate == Screen.currentResolution.refreshRate)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = PlayerPrefs.GetInt(resName, currentResolutionIndex);
        resolutionDropDown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];

        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void ChangeVol(float volume)
    {
        PlayerPrefs.SetFloat("MVolume", volume);
        volMixer.SetFloat("SfxVol", PlayerPrefs.GetFloat("MVolume"));
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;

        if(isFullScreen == false)
        {
            PlayerPrefs.SetInt("togglestate", 0);
        }
        else
        {
            isFullScreen = true;
            PlayerPrefs.SetInt("togglestate", 1);
        }
    }
}
