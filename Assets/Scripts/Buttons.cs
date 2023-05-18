using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {
    public void PlayBtn() {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void RecordBtn() {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }

    public void ExitBtn() {
        Application.Quit();
    }

    public void MenuBtn() {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
