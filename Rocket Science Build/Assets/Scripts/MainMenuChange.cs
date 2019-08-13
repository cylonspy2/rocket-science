using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuChange : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadScene(1);
    }
}
