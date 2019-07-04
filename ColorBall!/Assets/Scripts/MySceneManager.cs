using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoSingleton<MySceneManager>
{

    public void resetScene()
    {
        SceneManager.LoadScene("Emirhan's Scene");
    }
}
