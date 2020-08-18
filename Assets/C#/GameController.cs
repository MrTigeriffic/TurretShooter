//_____________________________________________________________________To be updated at later stage.
//This script is to handle game states Begin , Win, Lose or resert etc 
//This will deal with UI elements to hide and show game menu when game states change

using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {

    }

    public void PlayerHasDied()
    {

    }

    public void Restart()
    {
        ScoreManager.instance.ResetScore();
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
