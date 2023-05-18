using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
    private Shape shape;
    public bool isMoving = true;

    private void Start() {
        shape = GetComponentInParent<Shape>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        bool isBlock = collision.CompareTag("Block");

        if (collision.CompareTag("LeftBorder") || isBlock) {
            shape.canMoveLeft = false;
        } else if (collision.CompareTag("RightBorder") || isBlock) {
            shape.canMoveRight = false;
        }

        if (collision.CompareTag("Floor") || (isBlock && Mathf.Approximately(collision.transform.position.x, transform.position.x))) {
            shape.Stop();
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        shape.canMoveLeft = true;
        shape.canMoveRight = true;
    }
}