using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject generalMenu;
    public GameObject optionsMenu;


    // Start is called before the first frame update
    void Start()
    {
        ActiveMenu(generalMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Play Game
    public void Play() {
        // Deprecated
        // Application.LoadLevel("GamePlay");

        // SceneManager.LoadScene(2);
        SceneManager.LoadScene(5);
    }

    public void OpenGrimoire() {
        SceneManager.LoadScene(4);
    }

    public void ActiveMenu(GameObject menu) {
        HideMenus();
        menu.SetActive(true);
    }

    private void HideMenus() {
        generalMenu.SetActive(false);
        optionsMenu.SetActive(false);
    }

    public void ExitGame() {
        ApplicationController.ExitGame();
    }
}
