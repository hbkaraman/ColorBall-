using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
    [Header("GamePlay Panel")] 
    public GameObject levelStartPanel;
    
    [Header("GamePlay Panel")] 
    public GameObject levelPlayPanel;
    
    [Header("LevelCompleted Panel")] 
    public GameObject levelCompletePanel;

   /* public void ShowLevelStartPanel()
    {
        levelStartPanel.SetActive(true);
    }
    
    public void ShowLevelStartPanel()
    {
        levelStartPanel.SetActive(true);
    }*/
    public void ShowGamePlayPanel()
    {
        levelPlayPanel.SetActive(true);
    }
    public void HideGamePlayPanel()
    {
        levelPlayPanel.SetActive(false);
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
