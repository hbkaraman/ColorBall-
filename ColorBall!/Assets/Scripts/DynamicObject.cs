using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicObject : MonoBehaviour
{
    [Header("Transform Variables")]
    [SerializeField] private Vector3 defaultPosition;
    [SerializeField] private Quaternion defaultRotation;

    private Rigidbody rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        defaultPosition = transform.position;
        defaultRotation = transform.rotation;

    }

    public void reset()
    {
        transform.position = defaultPosition;
        transform.rotation = defaultRotation;
        rigid.velocity = Vector3.zero;
    }
}
