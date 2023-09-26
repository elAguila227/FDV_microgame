using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pause;
    public GameObject resume;

    public void TogglePause() {
        pause.SetActive(!pause.activeSelf);
        resume.SetActive(!resume.activeSelf);


        Time.timeScale = 1 - Time.timeScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            TogglePause();
        }

    }
}
