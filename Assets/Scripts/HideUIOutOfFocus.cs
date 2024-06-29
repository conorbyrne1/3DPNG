using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideUIOutOfFocus : MonoBehaviour
{
    public GameObject ui;
    bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        ui.SetActive(true);
    }
    void OnApplicationFocus(bool hasFocus)
    {
        isPaused = !hasFocus;
        Debug.Log("appication is focused");
        ui.SetActive(true);
    }

    void OnApplicationPause(bool pauseStatus)
    {
        isPaused = pauseStatus;

    }

    // Update is called once per frame
    void Update()
    {
        if (isPaused)
        {
            Debug.Log("appication is NOT focused");
            ui.SetActive(false);
        }
    }
}
