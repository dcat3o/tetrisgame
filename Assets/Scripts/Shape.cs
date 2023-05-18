using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shape : MonoBehaviour {
    private Coroutine fall;
    [SerializeField] public bool canMoveRight = true;
    [SerializeField] public bool canMoveLeft = true;
    [SerializeField] private bool isMoving = true;
    GameManager gameManager;

    float time = 0;

    Transform map;

    int speed = 1;

    private void Start() {
        gameManager = FindObjectOfType<GameManager>();
        map = GameObject.FindGameObjectWithTag("Map").transform;
        fall = StartCoroutine(Fall());
    }

    private void Update() {
        if (isMoving) {
            time += Time.deltaTime;
            Move();
        }
    }

    private void Move() {
        float x = 0;
        float y = 0;

        if (Input.GetKeyDown(KeyCode.A) && canMoveLeft) {
            x = -0.3f;
        } else if (Input.GetKeyDown(KeyCode.D) && canMoveRight) {
            x = 0.3f;
        }

        if (Input.GetKey(KeyCode.S) && isMoving) {
            speed = 8;
            if (time >= 1f / speed) {
                RestartCoroutine();
            }
        }

        if (Input.GetKeyUp(KeyCode.S)) {
            speed = 1;
        }

        transform.Translate(x, y, 0, Space.World);
    }

    private void Rotate() {
        if (Input.GetKeyDown(KeyCode.W) && isMoving && canMoveLeft && canMoveRight) {
            transform.eulerAngles += new Vector3(0, 0, -90);
        }
    }

    private void LateUpdate() {
        Rotate();
    }

    private void RestartCoroutine() {
        StopCoroutine(fall);
        fall = StartCoroutine(Fall());
    }

    IEnumerator Fall() {
        while (true) {
            time = 0;
            transform.Translate(0, -0.3f, 0, Space.World);
            yield return new WaitForSeconds(0.75f / speed);
        }
    }

    public void Stop() {
        if (isMoving == false) return;
        isMoving = false;
        StopCoroutine(fall);
        canMoveLeft = false;
        canMoveRight = false;

        while (transform.childCount > 0) {
            GameObject block = transform.GetChild(0).gameObject;
            block.GetComponent<Block>().isMoving = false;
            block.transform.SetParent(map);
            block.transform.eulerAngles = Vector3.zero;
            block.tag = "Block";
        }

        if (!gameManager.isEnd) {
            FindObjectOfType<GameManager>().StartRays();
            FindObjectOfType<GameManager>().SpawnShape();
        } else {
            End();
        }

        Destroy(gameObject);
    }

    public void End() {
        int newScores = gameManager.GetScores();
        int oldScores = PlayerPrefs.GetInt("scores");

        if (newScores > oldScores) {
            PlayerPrefs.SetInt("scores", newScores);
            PlayerPrefs.SetInt("oldScores", oldScores);
        }

        StopCoroutine(fall);
        SceneManager.LoadScene(3, LoadSceneMode.Single);
    }
}