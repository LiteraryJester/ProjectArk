using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{

    public Button StartButton;
    public Button QuitButton;


    // Start is called before the first frame update
    void Start()
    {
        StartButton.onClick.AddListener(NewGame);
        QuitButton.onClick.AddListener(QuitGame);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    private void NewGame()
    {
        SceneManager.LoadScene("PreperationPhase", LoadSceneMode.Single);
    }
}
