using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MenuItems : MonoSingleton<MenuItems>
{
    private static MySceneManager mySceneManager;
    private static StageManager stageManager;

    private void Awake()
    {
        mySceneManager = MySceneManager.Instance;
        stageManager = StageManager.Instance;
    }

    [MenuItem("Color Ball Menu/Level Up")]
    private static void LevelUp()
    {
        int level = stageManager.getLevel();
        stageManager.setLevel(++level);
    }

    [MenuItem("Color Ball Menu/Reset Level")]
    private static void ResetLevel()
    {
        mySceneManager.resetScene();
    }

    [MenuItem("Color Ball Menu/Reset All PlayerPrefs")]
    private static void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }

}
