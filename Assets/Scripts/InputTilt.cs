using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Camera))]
[RequireComponent(typeof(CameraFollow))]
public class InputTilt : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _target;

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
        Vector2 inputPosition;

        if (Application.platform == RuntimePlatform.Android && Input.touches.Length > 0)
        {
            inputPosition = Input.touches[0].position;
        }
        else if (Input.GetMouseButton((int)MouseButton.LeftMouse))
        {
            inputPosition = Input.mousePosition;
        }
        else
        {
            return;
        }


        var inputPositionX = ((Screen.width - inputPosition.x) / Screen.width - 0.5f) * 2f;
        var inputPositionY = ((Screen.height - inputPosition.y) / Screen.height - 0.5f) * 2f;

        // y converts into around z tilt
        // x converts into around x tilt


        // Debug.Log($"{inputPositionX}:{inputPositionY}");

        //_target.AddForce(inputPositionX, 0, inputPositionY);
        //_target.rotation = Quaternion.Euler(inputPositionX, 0, inputPositionY);

        inputPositionX *= 180 / Mathf.PI;
        inputPositionY *= 180 / Mathf.PI;

        _follow._offsetDirection.y = -inputPositionY;
        _follow._offsetDirection = _follow._offsetDirection.normalized;

        // _selfTransform.rotation =
        //     Quaternion.Euler(_selfTransform.rotation.x - inputPositionY, _selfTransform.rotation.y,
        //         _selfTransform.rotation.z - inputPositionX);
        // _selfTransform.Rotate(Vector3.right, -inputPositionY);
        // _selfTransform.Rotate(Vector3.up, -inputPositionX);
    }
}