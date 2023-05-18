using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordText : MonoBehaviour {
    private Text text;
    private void Start() {
        int scores = PlayerPrefs.GetInt("scores");
        text = GetComponent<Text>();

        text.text = $"Ваш рекорд: {scores}";
    }
}