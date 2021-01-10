using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Ez a script indítja el a játékot.
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    //Ez a script lépteti ki a felhasználót a játékból
    public void QuitGame()
    {
        Debug.Log("Quit!");  // Log fájlban kiírja, hogy sikeresen lefutott a parancs.
        Application.Quit();
    }
}
