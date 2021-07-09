using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [Header("Sensitivity")]
    public float Sensitivity;
    public Camera PlayerCamera;
    [SerializeField] private Transform _body;

    [Header("Zoom")]
    [SerializeField] private float _zoomSpeed = 0.07f;
    [SerializeField] private float _zoomValue = 30;
    [SerializeField] private KeyCode _zoomButton = KeyCode.Mouse1;

    [Header("Clamp Rotation")]
    [SerializeField] private float _minRotation = -90;
    [SerializeField] private float _maxRotation = 90;

    private Vector3 _clampVerticalRotation;
    private float _cachedZoom;

    private void Start()
    {
        PlayerCamera = GetComponent<Camera>();
        _cachedZoom = PlayerCamera.fieldOfView;
    }

    private void Update()
    {
        Zoom();
        MouseRotation();
    }

    private void MouseRotation()
    {
        if (PlayerStates.PlayerStatesScript.CanLook)
        {
            //Mouse Rotation
            float mouseHorizontal = Input.GetAxis("Mouse X") * Sensitivity;
            float mouseVertical = Input.GetAxis("Mouse Y") * -Sensitivity;

            _clampVerticalRotation.x += mouseVertical;
            _clampVerticalRotation.x = Mathf.Clamp(_clampVerticalRotation.x, _minRotation, _maxRotation);

            PlayerCamera.transform.Rotate(_clampVerticalRotation.x, 0f, 0f);
            PlayerCamera.transform.localEulerAngles = _clampVerticalRotation;

            //Body Rotation
            _body.Rotate(0f, mouseHorizontal, 0f);
        }
    }

    private void Zoom()
    {
        if (PlayerStates.PlayerStatesScript.CanZoom)
        {
            if (Input.GetKey(_zoomButton))
            {
                PlayerCamera.fieldOfView = Mathf.Lerp(PlayerCamera.fieldOfView, _zoomValue, _zoomSpeed);
            }
            else
            {
                PlayerCamera.fieldOfView = Mathf.Lerp(PlayerCamera.fieldOfView, _cachedZoom, _zoomSpeed);
            }
        }
    }
}
