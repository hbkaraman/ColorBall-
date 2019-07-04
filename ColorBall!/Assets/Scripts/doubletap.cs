using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doubletap : MonoBehaviour
{
    float _doubleTapTimeD;
    public List<Color> colorList; //renk listesi hazırladık
    int currentColorIndex = 0;


    // Update is called once per frame
    void Update()
    {
        MeshRenderer rend = GetComponent<MeshRenderer>();

        //double tap 
        bool doubleTapD = false;

        #region doubleTapD

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
}
