using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DyniamicObject : MonoBehaviour
{
    [Header("Transform Variables")]
    [SerializeField] private Vector3 defaultPosition;
    [SerializeField] private Quaternion defaultRotation;

    private void Awake()
    {
        
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
    }
}
