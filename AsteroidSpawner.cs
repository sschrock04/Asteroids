using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField]
    public GameObject asteroidPrefab;

    [SerializeField]
    public float spawnInterval = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(SpawnAsteroid), 0f, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnAsteroid()
    {
        //Debug.Log("spawning asteroid");
        int edge = Random.Range(0, 4);
        Vector3 position;
        if (edge == 0) {
            //top
            position = new Vector3(Random.Range(0f, 1f), 1.05f, 0f);
        }
        else if (edge == 1) {
            // bottom
            position = new Vector3(Random.Range(0f, 1f), -0.05f, 0f);
        }
        else if (edge == 2) {
            // left
            position = new Vector3(-0.05f, Random.Range(0f, 1f), 0f);
        }
        else
        {
            // right
            position = new Vector3(1.05f, Random.Range(0f, 1f), 0f);
        }

        position = Camera.main.ViewportToWorldPoint(position);
        position.z = 0f;

        Instantiate(asteroidPrefab, position, Quaternion.identity);
    }

}
