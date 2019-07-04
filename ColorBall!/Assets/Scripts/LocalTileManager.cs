using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalTileManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        int message = transform.childCount;
        Debug.Log(message: message);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
