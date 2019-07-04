using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using Cinemachine.Utility;
using UnityEditor;
using UnityEngine;

public class Player : MonoSingleton<Player>
{
    public float forwardSpeed;
    private Rigidbody _rb;
    private Transform target;
    private bool isMoving;
    private bool isLevelEnd;
   
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        AddForceMovement();
    }

    // Update is called once per frame
    void Update()
    {
        MovementController();
    }
    private void MovementController()
    {

        if (Input.GetMouseButton(0))
        {
            isMoving = true;

        }
        else if (Input.GetMouseButtonUp(0))
        {
            isMoving = false;
        }

        if (isLevelEnd)
        {
            forwardSpeed -= Time.deltaTime * 100;
            if (forwardSpeed <= 0)
            {
                forwardSpeed = 0;
            }
        }

    }
    private void AddForceMovement()
    {
        _rb.velocity = Vector3.forward * forwardSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GameEnd")
        {
            UIManager.Instance.ShowLevelCompletePanel();
            ParticleManager.Instance.LevelEndEffects();
            isLevelEnd = true;
        }
    }
}
