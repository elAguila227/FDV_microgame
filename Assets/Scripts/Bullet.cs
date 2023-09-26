using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour {
    public GameObject asteroidPrefab;
    public float speed = 1f;
    public float maxLifeTime = 3f;
    public Vector3 targetVector;

    // Start is called before the first frame update
    void Start() {
        Destroy(gameObject, maxLifeTime);
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(speed * targetVector * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemySmall")) {
            IncreaseScore();

            Destroy(collision.gameObject);

            if (collision.gameObject.CompareTag("Enemy")) {
                GameObject meteor = Instantiate(asteroidPrefab, transform.position, Quaternion.identity);
                Meteor meteorScript = meteor.GetComponent<Meteor>();
                meteorScript.targetVector = Quaternion.Euler(0, 0, 90) * targetVector;
                Destroy(meteor, maxLifeTime);

                GameObject meteor2 = Instantiate(asteroidPrefab, transform.position, Quaternion.identity);
                Meteor meteor2Script = meteor2.GetComponent<Meteor>();
                meteor2Script.targetVector = Quaternion.Euler(0, 0, -90) * targetVector;
                Destroy(meteor2, maxLifeTime);
            }

            Destroy(gameObject);
        }
    }

    private void IncreaseScore() {
        Player.SCORE++;
        UpdateScoreText();
    }

    private void UpdateScoreText() {
        GameObject go = GameObject.FindGameObjectWithTag("UI");
        go.GetComponent<Text>().text = "Score:" + Player.SCORE;
    }
}
