using UnityEngine;

public class Pipes : MonoBehaviour {

    public float speed = 5f;
    private float leftEdge;

    // Start is called before the first frame update
    void Start() {
        // as soon as pipe is past the screen we set the leftEdge as that
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - transform.lossyScale.x / 2;
    }

    // Update is called once per frame
    void Update() {
        // move the pipe to the left
        transform.position += Vector3.left * speed * Time.deltaTime;

        // Destroy the pipe when it reaches the end
        if (transform.position.x < leftEdge) {
            Destroy(gameObject);
        }
    }
}
