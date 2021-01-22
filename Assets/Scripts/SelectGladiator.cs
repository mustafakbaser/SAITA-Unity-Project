using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectGladiator : MonoBehaviour{
        
    public void Play() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void backToMainMenu() {
        SceneManager.LoadScene("Menu");
    }
}