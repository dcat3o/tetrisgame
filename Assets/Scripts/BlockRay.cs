using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRay : MonoBehaviour {
    [SerializeField] float rayDistance;

    public List<Block> blocks = new List<Block>();
    public int index;

    Vector3 rayStart;

    private void Start() {
        float size = GetComponent<SpriteRenderer>().sprite.bounds.size.x / 2f * transform.localScale.x + 0.1f;

        rayStart = transform.position + new Vector3(size, 0, 0);
    }

    private void Update() {
        Debug.DrawLine(rayStart, rayStart + new Vector3(rayDistance, 0, 0), Color.red);
    }

    public void StartRay() {
        RaycastHit2D[] hits = Physics2D.RaycastAll(rayStart, Vector2.right, rayDistance);

        if (hits.Length > 0) {
            blocks.Clear();
            for (int i = 0; i < hits.Length; i++) {
                if (hits[i].collider.CompareTag("Block")) {
                    blocks.Add(hits[i].collider.GetComponent<Block>());
                }
            }
        }
    }

    public void RemoveLine() {
        for (int i = 0; i < blocks.Count; i++) {
            Destroy(blocks[i].gameObject);
        }

        blocks.Clear();
    }
}
