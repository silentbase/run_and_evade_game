using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScreen : MonoBehaviour
{
    public GameObject panel;

    private GameObject g;

    private void Start()
    {
        
    }
    public void ReplayButton()
    {
        //g = GameObject.FindGameObjectWithTag("Player");
        //DontDestroyOnLoad(g);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        panel.SetActive(false);
    }
    public void BackToMainButton()
    {
        SceneManager.LoadScene("MainMenu");
        panel.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void EndGame()
    {
        Debug.Log("quit");
        panel.SetActive(false);
        Application.Quit();
    }
}
