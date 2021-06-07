using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScenesChanger : MonoBehaviour
{
    public int MenuSceneToLoad;

    public void ChangeScene()
    {
        SceneManager.LoadScene(MenuSceneToLoad);
    }
}
