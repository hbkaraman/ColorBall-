using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class doubletap : MonoBehaviour
{
    float _doubleTapTimeD;
    public List<Color> colorList; //renk listesi hazırladık
    int currentColorIndex = 0;

    Vector3 targetPosition = new Vector3(0, 0.5f, 0);
    Vector3 lookAtTarget = new Vector3(0,0.5f,0);
    [SerializeField] float rotSpeed = 5;
    [SerializeField] float speed = 10;
     bool moving = false;
    public LayerMask ground;
    public float yDegeri;
    [SerializeField] Image image;
    MeshRenderer rend;

    private void Start()
    {
        rend = GetComponent<MeshRenderer>();
        currentColorIndex =0;
        rend.material.SetColor("_Color", colorList[currentColorIndex]);
        image.color = colorList[currentColorIndex + 1];
    }
    // Update is called once per frame
    void Update()
    {
        //double tap 
        bool doubleTapD = false;

        #region doubleTapD
        if (Input.GetMouseButton(0))
        {
            SetTargetPosition();
        }
        Move();

        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time < _doubleTapTimeD + .3f)
            {
                doubleTapD = true;
                Debug.Log("double tab oldu");
                
                //daha sonra currentcolorindex değeri bir artsın ve diğer elemana geçsin
                if (currentColorIndex + 1 == 5)
                {
                    image.color = colorList[0];
                }
                else
                {
                    image.color = colorList[currentColorIndex + 1];
                }
                rend.material.SetColor("_Color", colorList[currentColorIndex]);
                currentColorIndex++;
            }

            _doubleTapTimeD = Time.time;
            //listenin son elemanına gelince currencolorindex' in değeri 0 olsun

            if (currentColorIndex == 5)
            {
                currentColorIndex = 0;
            }
        }
        #endregion
    }

    void SetTargetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 1000, ground))
        {
           targetPosition = new Vector3(hit.point.x,yDegeri,hit.point.z);
           lookAtTarget = new Vector3(targetPosition.x - transform.position.x,
                                       transform.position.y,
                                       targetPosition.z - transform.position.z);
            moving = true;
        }
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position,
                                                 targetPosition,
                                                 speed * Time.deltaTime);

        if (transform.position == targetPosition)
            moving = false;
    }
}
