using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalTileManager : MonoBehaviour
{
    [SerializeField] List<DynamicObject> childrenObject;
    void Start()
    {
        int childrenCount = transform.childCount;

        for (int i = 0; i < childrenCount; i++)
        {
            DynamicObject child = transform.GetChild(i).GetComponent<DynamicObject>();
            childrenObject.Add(child);
        }
    }


    public void resetPrefab()
    {
        for(int i=0; i<childrenObject.Count; i++)
        {
            childrenObject[i].reset();
        }
    }
}
