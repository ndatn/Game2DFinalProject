using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraController : Singleton<CameraController>
{
    private CinemachineVirtualCamera cinemachineVirtualCamera;
    private SmoothCameraFollow smoothCameraFollow;

    public void SetPlayerCameraFollow()
    {
        cinemachineVirtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        cinemachineVirtualCamera.Follow = PlayerController.Instance.transform;
        smoothCameraFollow = FindAnyObjectByType<SmoothCameraFollow>();
        smoothCameraFollow.target = PlayerController.Instance.transform;
    }

}
