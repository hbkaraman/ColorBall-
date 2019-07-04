using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoSingleton<ObjectPoolManager>
{
    #region Object Pool
    [System.Serializable]
    public class ObjectPool
    {
        public int objectType;
        public int length;

        public GameObject objectPrefab;
    }
    #endregion

    #region Pools
    [Header("Pools")]
    [SerializeField] List<ObjectPool> pools;
    Dictionary<int, Queue<GameObject>> poolDictionary;
    #endregion

    #region Functions
    public void Awake()
    {
        poolDictionary = new Dictionary<int, Queue<GameObject>>();

        foreach (ObjectPool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.length; i++)
            {
                GameObject objects = Instantiate(pool.objectPrefab);
                objects.SetActive(false);
                objectPool.Enqueue(objects);
            }

            poolDictionary.Add(pool.objectType, objectPool);

        }
    }

    public void closeObjects()
    {
        for (int i = 0; i < poolDictionary.Count; i++)
        {
            for (int j = 0; j < poolDictionary[i].Count; j++)
            {
                GameObject objects = poolDictionary[i].Dequeue();
                objects.SetActive(false);
                poolDictionary[i].Enqueue(objects);
            }
        }
    }


    public GameObject spawnObject(int objectType, Vector3 position)
    {
        if (!poolDictionary.ContainsKey(objectType))
            return null;

        GameObject objects = poolDictionary[objectType].Dequeue();
        LocalTileManager localTileManager = objects.GetComponent<LocalTileManager>();

        localTileManager.resetPrefab();

        objects.transform.position = position;
        objects.SetActive(true);

        poolDictionary[objectType].Enqueue(objects);

        return objects;

    }
    #endregion
}
