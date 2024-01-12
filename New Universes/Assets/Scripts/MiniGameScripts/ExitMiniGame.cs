using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ExitMiniGame : MonoBehaviour
{
    public void ExitMiniGames()
    {
        SceneManager.LoadScene("MainScene");
    }
}
