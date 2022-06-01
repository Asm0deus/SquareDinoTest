using UnityEngine;

public class CamRotationToAim : MonoBehaviour
{
    [SerializeField] private float _mouseSensitivity = 0.025f;
    private Vector3 _mousePreveousePos;
    private float _rotationX;
    private float _rotationY;

    private void Update()
    {
        Vector3 _mouseDelta;

        if (Input.GetMouseButtonDown(0))
        {
            _mousePreveousePos = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            _mouseDelta = Input.mousePosition - _mousePreveousePos;
            _mousePreveousePos = Input.mousePosition;

            _rotationX -= _mouseDelta.y * _mouseSensitivity;
            _rotationY += _mouseDelta.x * _mouseSensitivity;

            Quaternion rotation = Quaternion.Euler(_rotationX, _rotationY, 0f);

            transform.localRotation = rotation;
        }
    }
}
