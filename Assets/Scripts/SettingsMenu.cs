using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    public AudioMixer audioMixer;
    // Start is called before the first frame update

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
    
}
