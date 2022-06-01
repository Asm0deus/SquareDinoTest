using UnityEngine;

public class CanvasToCamera : MonoBehaviour
{
    private Transform _cameraTransform;

    private void Start()
    {
        _cameraTransform = Camera.main.transform;
    }
    private void LateUpdate()
    {
        transform.rotation = _cameraTransform.rotation;
    }
}
