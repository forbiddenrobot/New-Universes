using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameEnter : MonoBehaviour
{
    private void OnMouseDown()
    {
        GameMaster.SaveData();
        SceneManager.LoadScene("MiniGameShooting");
    }

}
