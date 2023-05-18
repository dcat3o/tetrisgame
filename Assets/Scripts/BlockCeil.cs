using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockCeil : MonoBehaviour {
    private readonly float rayDistance = 4.5f;

    Vector3 rayStart;

    GameManager gameManager;

    private void Start() {
        gameManager = FindObjectOfType<GameManager>();
        rayStart = transform.position + new Vector3(0.1f, 0, 0);
    }

    private void Update() {
        Debug.DrawLine(rayStart, rayStart + new Vector3(rayDistance, 0, 0), Color.black);

        RaycastHit2D hit = Physics2D.Raycast(rayStart, Vector2.right, rayDistance);

        if (hit.collider) {
            bool isBlock = hit.collider.CompareTag("Block");
            if (isBlock) {
                GameObject objectHit = hit.collider.gameObject;
                Shape shape = objectHit.GetComponent<Shape>();
                gameManager.isEnd = true;
            }
        }
    }
}
