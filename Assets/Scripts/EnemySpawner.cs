using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public GameObject asteroidPrefab;
    public float spawnRate = 30f;
    public float spawnRateIncrement = 1f;

    private float xlimit;
    public float MaxTimeLife = 2f;

    private float _spawnNext = 0f;

    // Start is called before the first frame update
    void Start() {
        xlimit = (Camera.main.orthographicSize+1) * Screen.width/Screen.height;
    }

    // Update is called once per frame
    void Update() {
        if (Time.time > _spawnNext) {
            _spawnNext = Time.time + 60/spawnRate;
            spawnRate += spawnRateIncrement;

            Vector2 spawnPosition = new Vector2(Random.Range(-xlimit, xlimit), 8);

            GameObject meteor = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
            Destroy(meteor, MaxTimeLife);
        }

    }
}
