using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndSceneText : MonoBehaviour {
    private void Start() {
        Run();
    }

    private void Run() {
        int oldScores = PlayerPrefs.GetInt("oldScores");
        int scores = PlayerPrefs.GetInt("scores");
        Text text = GetComponent<Text>();

        Debug.Log(text);

        if (oldScores > scores) {
            text.text = $"�� ������ ���� ������!\n�����: {scores}";
        } else {
            text.text = $"\n�����: {scores}";
        }
    }
}