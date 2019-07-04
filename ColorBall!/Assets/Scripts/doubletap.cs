using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


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

    // Update is called once per frame
    void Update()
    {
        MeshRenderer rend = GetComponent<MeshRenderer>();

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
                //dizideki elemana gore sırasıyla renkler değişsin
                rend.material.SetColor("_Color", colorList[currentColorIndex]);
                //daha sonra currentcolorindex değeri bir artsın ve diğer elemana geçsin
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
           targetPosition = new Vector3(hit.point.x,0.5f,hit.point.z);
          //  this.transform.LookAt(targetPosition);
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
