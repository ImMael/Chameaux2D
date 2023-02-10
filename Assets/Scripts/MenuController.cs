using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void ChangeScene(string _sceneName) {
        Debug.Log("test");
        SceneManager.LoadScene(_sceneName);
    }

}
