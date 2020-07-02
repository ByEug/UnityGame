using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingMenuScript : MonoBehaviour
{
    public Canvas settings;

    public AudioMixer audioMixer;

    public Slider speed_slider;

    public Slider volume_slider;

    public Dropdown resolution_dropdown;

    Resolution[] resolutions;

    void Start()
    {
        speed_slider.value = Time.timeScale;
        volume_slider.value = AudioController.volume;
        resolutions = Screen.resolutions;

        resolution_dropdown.ClearOptions();

        List<string> options = new List<string>();

        int current_res_index = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].height == Screen.currentResolution.height && resolutions[i].width == Screen.currentResolution.width)
            {
                current_res_index = i;
            }
        }

        resolution_dropdown.AddOptions(options);
        resolution_dropdown.value = current_res_index;
        resolution_dropdown.RefreshShownValue();
    }

    public void SetResolution(int res_index)
    {
        Resolution res = resolutions[res_index];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        AudioController.volume = volume;
    }

    public void SetSpeed(float speed)
    {
        Time.timeScale = speed;
    }

    public void BackToMainMenu()
    {
        settings.enabled = !settings.enabled;
    }

    public void FullScreen(bool isItFull)
    {
        Screen.fullScreen = isItFull;
    }
}
