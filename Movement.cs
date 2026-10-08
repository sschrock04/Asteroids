using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float speed = 0f;
    public float rotate = 180f;
    private bool left = false;
    private bool right = false;
    private float moveInput;
    public GameObject bulletPrefab;
    public float acceleration = 3f;
    public float maxSpeed = 7f;
    public float deceleration = 4f;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (moveInput > 0) {
            speed += acceleration * Time.deltaTime;
        }
        else {
            speed -= deceleration * Time.deltaTime;
        }

        speed = Mathf.Clamp(speed, 0f, maxSpeed);

        transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (left) {
            transform.Rotate(Vector3.forward * rotate * Time.deltaTime);
        }
        if (right) {
            transform.Rotate(Vector3.forward * -rotate * Time.deltaTime);
        }

        isOffScreen();
    }

    void OnMoveForward(InputValue value) {
        Debug.Log("forward");
        moveInput = value.Get<float>();
        Debug.Log("Move Input: " + moveInput);
        
    }

    void OnTurnLeft(InputValue value) {
        Debug.Log("Left");
        left = value.isPressed;
    }

    void OnTurnRight(InputValue value) {
        Debug.Log("Right");
        right = value.isPressed;
    }

    void isOffScreen() {
        Vector3 screenPosition = Camera.main.WorldToViewportPoint(transform.position);
        if (screenPosition.x > 1) {
            screenPosition.x = 0;
        }
        else if (screenPosition.x < 0) {
            screenPosition.x = 1;
        }
        if (screenPosition.y > 1) {
            screenPosition.y = 0;
        }
        else if (screenPosition.y < 0) {
            screenPosition.y = 1;
        }
        transform.position = Camera.main.ViewportToWorldPoint(screenPosition);
    
    }

    void OnShoot(InputValue value) {
        Debug.Log("shoot");
        if (value.isPressed) { 
            Instantiate(bulletPrefab, transform.position, transform.rotation); 
        }
    }

}
