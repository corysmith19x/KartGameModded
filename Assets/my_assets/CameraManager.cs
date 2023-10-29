using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public CinemachineVirtualCamera[] cameras;

    public CinemachineVirtualCamera mainCamera;
    public CinemachineVirtualCamera topCamera;

    public CinemachineVirtualCamera startCamera;
    public CinemachineVirtualCamera currentCamera;

    // Start is called before the first frame update
    void Start()
    {
        currentCamera = startCamera;

        for (int i = 0; i < cameras.Length; i++)
        {
            if(cameras[i] == currentCamera)
            {
                cameras[i].Priority = 20;
            }
            else
            {
                cameras[i].Priority = 10;
            }
        }
    }

    public void SwitchCamera(CinemachineVirtualCamera newCamera)
    {
        currentCamera = newCamera;

        currentCamera.Priority = 20;

        for (int i = 0; i < cameras.Length; i++)
        {
            if (cameras[i] != currentCamera)
            {
                cameras[i].Priority = 10;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            SwitchCamera(topCamera);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            SwitchCamera(mainCamera);
        }
    }
}
