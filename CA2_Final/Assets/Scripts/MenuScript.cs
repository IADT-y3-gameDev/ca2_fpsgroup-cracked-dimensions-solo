using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    // StartGame is a script for the Start button
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    // ExitGame is is a script for the Exit button
    public void ExitGame()
    {
        Application.Quit();
    }

        public void DevLevel1()
    {
        SceneManager.LoadScene(1);
    }

        public void DevLevel2()
    {
        SceneManager.LoadScene(2);
    }


}
