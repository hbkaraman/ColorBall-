using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    private Rigidbody _rb;
    public Vector3 target;
    private bool isMoving;

    // Start is called before the first frame update
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
        Debug.Log(isMoving);
        MovementController();
    }

    private void MovementController()
    {
        if (Input.GetMouseButton(0))
        {
            isMoving = true;
            target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x , 0.7f, Input.mousePosition.z / Screen.width));
            Debug.Log(target);

        }
        else if (Input.GetMouseButtonUp(0))
        {
            isMoving = false;
        }
        
    }

    private void AddForceMovement()
    {
        if (isMoving)
        {
            _rb.MovePosition(target * speed * Time.deltaTime);
        }
    }
}
