using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    Transform _target;

    [SerializeField]
    private float _distance;

    [SerializeField]
    public Vector3 _offsetDirection;

    [SerializeField]
    [Range(0, 1)]
    public float _easing;

    private Transform _selfTransform;

    private Vector3 _lookAt;

    // Start is called before the first frame update
    void Start()
    {
        _selfTransform = transform;
        _lookAt = _target.position;
    }

    // Update is called once per frame
    void Update()
    {
        _selfTransform.position =
            Vector3.Lerp(_selfTransform.position, _lookAt + _offsetDirection * _distance, _easing);
        _lookAt = Vector3.Lerp(_lookAt, _target.position, _easing);
        _selfTransform.rotation = Quaternion.Lerp(_selfTransform.rotation,
            Quaternion.LookRotation(_lookAt - _selfTransform.position, Vector3.up), _easing);
        // Destroy(this);
    }
}