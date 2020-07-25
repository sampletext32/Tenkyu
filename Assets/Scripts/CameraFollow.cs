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

    private Transform _selfTransform;

    // Start is called before the first frame update
    void Start()
    {
        _selfTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        _selfTransform.position = Vector3.Lerp(_selfTransform.position, _target.position + _offsetDirection * _distance, 0.8f);
        _selfTransform.LookAt(_target);
        // Destroy(this);
    }
}
