using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMain : MonoBehaviour{

    [Header("UIPages")]
    public GameObject mainScreen;
    public GameObject settingsScreen;

    public Text text;
 
    
    public void Play(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LobbySelected()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Settings(){
        mainScreen.SetActive(false);
        settingsScreen.SetActive(true);

    }

    public void backToMainMenu()    {
        SceneManager.LoadScene("Menu");
    }

    public void Mute()
    {
        text.text = "off";
        text.color = Color.red;
        AudioListener.volume = 0f;
        Debug.Log("Sounds muted. Volume = 0.");
    }

    public void UnMute()
    {       
        text.text = "on";
        text.color = Color.green;
        AudioListener.volume = 100.0f;
        Debug.Log("Sounds unmuted. Volume = 100.");

    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Guide()
    {
        SceneManager.LoadScene("Guide");
    }
}