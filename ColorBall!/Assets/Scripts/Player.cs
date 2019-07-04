using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using Cinemachine.Utility;
using UnityEditor;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Player : MonoSingleton<Player>
{
    public GameObject CameraFollowTarget;
    public float forwardSpeed;
    private Rigidbody _rb;
    private Transform target;
    private bool isMoving;
    private bool isLevelEnd;
    private bool isStart = false;
    public MeshRenderer rend;
    
    float _doubleTapTimeD;
    public List<Color> colorList; //renk listesi hazırladık
    int currentColorIndex = 0;

    Vector3 targetPosition = new Vector3(0, 0.5f, 0);
    Vector3 lookAtTarget = new Vector3(0,0.5f,0);
    [SerializeField] float rotSpeed = 5;
    [SerializeField] float speed = 10;
    bool moving = false;
    public bool isDead;
    [SerializeField] Image image;
    public LayerMask ground;
   
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        currentColorIndex = 0;
        image.color = colorList[1];
        rend.material.SetColor("_Color", colorList[currentColorIndex]);
        
    }


    private void FixedUpdate()
    {
        if (isMoving)
        {
            Move();
        }
        else
        {
            AddForceMovement();
        }
               
        CameraFollowTarget.GetComponent<Rigidbody>().velocity = Vector3.forward * forwardSpeed * Time.deltaTime;

    }

    // Update is called once per frame
    void Update()
    {
        rend.material.SetColor("_Color", colorList[currentColorIndex]);

        if (isDead)
        {
            rend.gameObject.SetActive(false);
        }
       
        //double tap 
        bool doubleTapD = false;

        #region doubleTapD
        
        if (Input.GetMouseButton(0))
        {
            SetTargetPosition();
        }
 
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time < _doubleTapTimeD + .2f)
            {
                doubleTapD = true;
                currentColorIndex++;
                if (currentColorIndex == 3)
                {
                    currentColorIndex = 0;
                }
                
                if (currentColorIndex + 1 == 3)
                {
                    image.color = colorList[0];
                }
                else
                {
                    image.color = colorList[currentColorIndex + 1];
                }
                
               
            }
            else
            {
                doubleTapD = false;
            }
            
            _doubleTapTimeD = Time.time;
           
        }
        
        #endregion
        

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
            transform.DOKill();
        }

        if (isLevelEnd)
        {
            forwardSpeed -= Time.deltaTime * 110;
            if (forwardSpeed <= 0)
            {
                forwardSpeed = 0;
            }
        }
    }
    
    void Move()
    {

        transform.DOMove(targetPosition, 1, false);

        if (transform.position == targetPosition)
        {
            moving = false;
        }
    }
    
    void SetTargetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 1000, ground))
        {
            targetPosition = new Vector3(hit.point.x,0.5f,hit.point.z);
            //  this.transform.LookAt(targetPosition);
            lookAtTarget = new Vector3(targetPosition.x - transform.position.x,
                transform.position.y,
                targetPosition.z - transform.position.z);
            moving = true;
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
            StartCoroutine(ParticleManager.Instance.LevelEndEffects());
            isLevelEnd = true;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Red")
        {
            if (currentColorIndex == 0)
            {
                isDead = false;
            }
            else if(currentColorIndex == 1)
            {
                isDead = true;
            }
            else if(currentColorIndex == 2)
            {
                isDead = true;
            }
        }
        
        if (other.gameObject.tag == "Blue")
        {
            if (currentColorIndex == 1)
            {
                isDead = false;
            }
            else if(currentColorIndex == 0)
            {
                isDead = true;
            }
            else if(currentColorIndex == 2)
            {
                isDead = true;
            }
        }
        
        if (other.gameObject.tag == "Green")
        {
            if (currentColorIndex == 2)
            {
                isDead = false;
            }
            else if(currentColorIndex == 0)
            {
                isDead = true;
            }
            else if(currentColorIndex == 1)
            {
                isDead = true;
            }
        }
    }
}
