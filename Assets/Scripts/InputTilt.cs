using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Camera))]
[RequireComponent(typeof(CameraFollow))]
public class InputTilt : MonoBehaviour
{
    [SerializeField]
    private Transform _target;

    private Transform _selfTransform;

    private CameraFollow _follow;

    // Start is called before the first frame update
    void Start()
    {
        _selfTransform = transform;
        _follow = GetComponent<CameraFollow>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition;

        if (Application.platform == RuntimePlatform.Android && Input.touches.Length > 0)
        {
            mousePosition = Input.touches[0].position;
        }
        else if (Input.GetMouseButton((int)MouseButton.LeftMouse))
        {
            mousePosition = Input.mousePosition;
        }
        else
        {
            return;
        }

        // y converts into around z tilt
        // x converts into around x tilt

        Vector3 inputTiltAngle = new Vector3(
            ((Screen.width - mousePosition.x) / Screen.width - 0.5f) * 2f,
            0,
            ((Screen.height - mousePosition.y) / Screen.height - 0.5f) * 2f
        );

        // Debug.Log($"{inputPositionX}:{inputPositionY}");

        // _target.AddForce(inputPositionX, 0, inputPositionY);

        // -90 to 90 degrees
        inputTiltAngle *= 180 / Mathf.PI;

        // -18 to 18 degrees
        inputTiltAngle *= 1 / 5f;

        _target.rotation = Quaternion.Lerp(_target.rotation, Quaternion.Euler(inputTiltAngle), 0.5f);

        // 
        // _follow._offsetDirection.y = -inputPositionY;
        // _follow._offsetDirection = _follow._offsetDirection.normalized;

        // _selfTransform.rotation =
        //     Quaternion.Euler(_selfTransform.rotation.x - inputPositionY, _selfTransform.rotation.y,
        //         _selfTransform.rotation.z - inputPositionX);
        // _selfTransform.Rotate(Vector3.right, -inputPositionY);
        // _selfTransform.Rotate(Vector3.up, -inputPositionX);
    }
}