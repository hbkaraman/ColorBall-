using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoSingleton<StageManager>
{
    #region Variables
    [Header("Level Variables")]
    [SerializeField] private int currentLevel;

    ObjectManager objectManager;

    #endregion

    #region Functions
    private void Awake()
    {
        objectManager = ObjectManager.Instance;
    }

    private void Start()
    {
        currentLevel = 2;
        setLevel(currentLevel);
    }

    public void setLevel(int level)
    {
        currentLevel = level;

        int length = currentLevel * 5;

        objectManager.spawnObjects(length);
    }

    public void levelUp()
    {

    }

    #endregion

}
