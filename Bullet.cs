using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    public float speed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        isOffScreen();
    }

    void isOffScreen() {
        Vector3 screenPosition = Camera.main.WorldToViewportPoint(transform.position);
        if (screenPosition.x > 1 || screenPosition.x < 0 || screenPosition.y > 1 || screenPosition.y < 0) {
            Destroy(gameObject);
        }
    
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Asteroid")) {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
