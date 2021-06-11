using UnityEngine;
using Cinemachine;

public class CameraController: MonoSingletonGeneric<CameraController>
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    public void SetTarget(Transform target)
    {
        virtualCamera.Follow = target;
    }
}
