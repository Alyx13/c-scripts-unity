using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera[] cameras;
    private int currentCameraIndex;

    private void Start()
    {
        cameras = new Camera[] {
            GameObject.Find("Main Camera").GetComponent<Camera>(),
            GameObject.Find("FPV Camera").GetComponent<Camera>()
        };

        currentCameraIndex = 0;
        for (int i = 1; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);
        }

        if (cameras.Length > 0)
        {
            cameras[0].gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            currentCameraIndex++;
            if (currentCameraIndex < cameras.Length)
            {
                cameras[currentCameraIndex - 1].gameObject.SetActive(false);
                cameras[currentCameraIndex].gameObject.SetActive(true);
            }
            else
            {
                cameras[currentCameraIndex - 1].gameObject.SetActive(false);
                currentCameraIndex = 0;
                cameras[currentCameraIndex].gameObject.SetActive(true);
            }
        }
    }
}