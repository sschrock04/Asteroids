using UnityEngine;
using UnityEngine.SceneManagement;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    public float speed = 3f;
    private Vector3 direction;
    [SerializeField]
    public Sprite[] asteroidSprites;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int randomIndex = Random.Range(0, asteroidSprites.Length);
        GetComponent<SpriteRenderer>().sprite = asteroidSprites[randomIndex];
        direction = Random.insideUnitCircle.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
        isOffScreen();
    }

    public void SetDirection(Vector3 newDirection) {
        direction = newDirection;
    }

    void isOffScreen() {
        Vector3 screenPosition = Camera.main.WorldToViewportPoint(transform.position);
        if (screenPosition.x > 1.1 || screenPosition.x < -0.1 || screenPosition.y > 1.1 || screenPosition.y < -0.1) {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        Debug.Log("die");
    }
}
