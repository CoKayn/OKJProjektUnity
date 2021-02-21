using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public void RespawnPlayer()
    {
        backgroundMusic.Stop();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
