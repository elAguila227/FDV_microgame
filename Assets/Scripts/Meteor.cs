using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float speed = 5f;
    public float maxLifeTime = 5f;

    public Vector3 targetVector;

    // Start is called before the first frame update
    void Start() {
        Destroy(gameObject, maxLifeTime);
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(speed * targetVector * Time.deltaTime);
    }
}
