using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public int currentTurn = 1;
    public int totalHp;
    public int totalMana;
    public string altPowerSource;
    public int altPowerSourcePoints;
    public static GameController instance;
    public PlayerController player1;
    public PlayerController player2;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitGame() {
        // Deprecated
        // Application.LoadLevel("Menu");

        SceneManager.LoadScene(1);
    }
}
