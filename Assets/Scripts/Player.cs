using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    public float thrustForce = 100f;
    public float rotationSpeed = 100f;

    public GameObject gun, bulletPrefab;

    public static int SCORE = 0;
    public static float xBorderLimit, yBorderLimit;

    private Rigidbody _rigid;

    // Start is called before the first frame update
    void Start() {
        _rigid = GetComponent<Rigidbody>();

        yBorderLimit = Camera.main.orthographicSize+1;
        xBorderLimit = (Camera.main.orthographicSize+1) * Screen.width/Screen.height;
    }

    // Update is called once per frame
    void Update() {
        float rotation = Input.GetAxis("Rotation") * Time.deltaTime;
        float thrust = Input.GetAxis("Thrust") * Time.deltaTime;

        Vector3 thrustDirection = transform.right;

        _rigid.AddForce(thrustDirection * thrust *thrustForce);
        transform.Rotate(Vector3.forward, -rotation * rotationSpeed);

        Vector3 temp = transform.position;
        // temp.x = (temp.x+xBorderLimit)%(2*xBorderLimit) - xBorderLimit;
        // temp.y = (temp.y+yBorderLimit)%(2*yBorderLimit) - yBorderLimit;
        if (Math.Abs(temp.x)+0.5 > xBorderLimit) {
            temp.x = -temp.x;
        }
        if (Math.Abs(temp.y)+0.5 > yBorderLimit) {
            temp.y = -temp.y;
        }
        transform.position = temp;


        if (Input.GetKeyDown(KeyCode.Space)) {
            GameObject bullet = Instantiate(bulletPrefab, gun.transform.position, Quaternion.identity);

            Bullet bulletScript = bullet.GetComponent<Bullet>();
            bulletScript.targetVector = transform.right;
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemySmall")) {
            SCORE = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
