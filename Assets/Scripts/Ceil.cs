using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ceil : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision) {
        bool isBlock = collision.CompareTag("Block");
        Shape shape = FindObjectOfType<Shape>();

        if (isBlock) {
            shape.End();
        }
    }
}
