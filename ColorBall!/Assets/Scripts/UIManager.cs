using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
    [Header("GamePlay Panel")] 
    public GameObject gamePlayPanel;
    
    [Header("LevelCompleted Panel")] 
    public GameObject levelCompletePanel;

    public void ShowGamePlayPanel()
    {
        gamePlayPanel.SetActive(true);
    }

    public void HideGamePlayPanel()
    {
        gamePlayPanel.SetActive(false);
    }
    public void ShowLevelCompletePanel()
    {
        levelCompletePanel.SetActive(true);
    }
    public void HideLevelCompletePanel()
    {
        levelCompletePanel.SetActive(false);
    }
}
