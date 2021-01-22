using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour {

    private GameObject[] characterList;
    private int index;
    public static int data;

    public void Start() {

        index = PlayerPrefs.GetInt("CharacterSelected");

        characterList = new GameObject[transform.childCount];  //gladyatör sayısını verecek

        //Array'i gladyatörlerle doldurmak
        for (int i = 0; i < transform.childCount; i++)
        {
            characterList[i] = transform.GetChild(i).gameObject;
        }

            foreach (GameObject go in characterList)
                go.SetActive(false);

            if (characterList[index])
                characterList[index].SetActive(true);

    }

        public void ToggleLeft() {

            //toggle off the current model
            characterList[index].SetActive(false);

            index--;

        if (index < 0) {
            index = (characterList.Length - 1);
        }

            // toggle on the new model
            characterList[index].SetActive(true);
        }

        public void ToggleRight()
        {

            //toggle off the current model
            characterList[index].SetActive(false);

            index++;

        if (index == characterList.Length){
            index = 0;
        }

            // toggle on the new model
            characterList[index].SetActive(true);
        }

    public void SelectButton() {
        PlayerPrefs.SetInt("CharacterSelected", index);
        SceneManager.LoadScene("Main");
        Debug.Log(index);
    }

    public static void Get()    {
        data = PlayerPrefs.GetInt("CharacterSelected");
    }
}