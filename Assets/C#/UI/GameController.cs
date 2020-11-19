//_____________________________________________________________________To be updated at later stage.
//This script is to handle game states Begin , Win, Lose or resert etc 
//This will deal with UI elements to hide and show game menu when game states change

using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
//using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update

    public void StartGame()
    {
        //Debug.Log("Load Game");
        SceneManager.LoadScene("MainGameScene");
    }

    public void PlayerHasDied()
    {

    }

    public void Restart()
    {
        //ScoreManager.instance.ResetScore();
        
    }

    public void Settings()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
