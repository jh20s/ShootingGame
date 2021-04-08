using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartSceneManager : MonoBehaviour
{
    public GameObject GameStartButton;
    // Start is called before the first frame update
    public void Awake()
    {
        Screen.SetResolution(640, 960, true);
    }

    void Start()
    {

    }
    public void StartGame()
    {
       
        SceneManager.LoadScene("Main");
    }
}
