using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    [SerializeField] Transform spawn;
    [SerializeField] GameObject[] shapes;
    [SerializeField] BlockRay[] lines;

    [SerializeField] Text scoresTxt;
    private int scores = 0;

    public bool isEnd = false;

    Vector3 offset;

    private void Start() {
        scores = 0;
        scoresTxt.text = $"Ñ÷¸ò: {scores}";

        offset = new Vector3(0, -0.3f, 0);

        for (int i = 0; i < lines.Length; i++) {
            lines[i].index = i;
        }

        SpawnShape();
    }

    public int GetScores() {
        return scores;
    }

    public void SpawnShape() {
        int index = Random.Range(0, shapes.Length);
        GameObject shape = Instantiate(shapes[index], spawn.position, Quaternion.identity);

        index = Random.Range(0, 4);
        shape.transform.eulerAngles = new Vector3(0, 0, index * 90);
    }

    public void StartRays() {
        for (int i = 0; i < lines.Length; i++) {
            lines[i].StartRay();
        }

        CheckLines();
    }

    private void CheckLines() {
        for (int i = 0; i < lines.Length; i++) {
            if (lines[i].blocks.Count == 17) {
                lines[i].RemoveLine();
                scores++;
                scoresTxt.text = $"Ñ÷¸ò: {scores}";
                DropLines(i);
                break;
            }
        }
    }

    private void DropLines(int startIndex) {
        for (int i = startIndex + 1; i < lines.Length; i++) {
            BlockRay line = lines[i];
            for (int j = 0; j < line.blocks.Count; j++) {
                line.blocks[j].gameObject.transform.position += offset;
            }
        }

        StartRays();
    }
}
