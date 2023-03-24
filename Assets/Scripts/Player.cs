using UnityEngine;

public class Player : MonoBehaviour {
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;
    private Vector3 direction;
    public float gravity = -9.8f;
    public float strength = 5f;

    private void Awake() {
        // this runs just once
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start() {
        /*
            Invokes the method methodName in time seconds, then repeatedly every repeatRate seconds.
        */
        InvokeRepeating(nameof(AnimateSprite), time: 0.15f, repeatRate: 0.15f);
    }
    private void Update() {
        // space bar or left click
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.UpArrow)) {
            direction = Vector3.up * strength;
        }
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            // when user begins to touch 
            // we move the bird up
            if (touch.phase == TouchPhase.Began) {
                direction = Vector3.up * strength;
            }
        }


        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
        // multiplying by Time.deltaTime ensures that 
        // behaviour of bird is frame rate independent
        // higher frame rate doesn't leads to faster
    }
    private void AnimateSprite() {
        spriteIndex++;
        if (spriteIndex >= sprites.Length) {
            spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[spriteIndex];
    }
}
