using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoSingleton<ObjectManager>
{
    #region Variables
    ObjectPoolManager objectPoolManager;
    [Header("Random Variables")]
    [SerializeField] int randomTypeValueUpperLimit = 3, randomTypeValueLowerLimit = 0;
    [Header("Position Variables")]
    [SerializeField] Vector3 nextPosition = Vector3.zero;
    [SerializeField] Vector3 stepVector = new Vector3(0,0,5);

    #endregion

    #region Functions
    private void Awake()
    {
        objectPoolManager = ObjectPoolManager.Instance;

        nextPosition = stepVector;
    }

    public void closeObjects()
    {
        nextPosition = stepVector;
        objectPoolManager.closeObjects();
    }

    public void spawnObjects(int numberOfObjects)
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            int randomType = Random.Range(randomTypeValueLowerLimit, randomTypeValueUpperLimit);
            objectPoolManager.spawnObject(randomType, nextPosition);
            nextPosition += stepVector;
        }
    }
    #endregion
}
