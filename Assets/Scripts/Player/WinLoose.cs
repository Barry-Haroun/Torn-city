using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoose : MonoBehaviour
{
    public GameObject winPanel;
    public WinGoal winGoalScript;

    private bool gameEnded;
    public void WinLevel()
    {
        if (!gameEnded)
        {
            Debug.Log("You Win!");
            winPanel.SetActive(true);
            gameEnded = true;
        }

    }
    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LooseLevel()
    {
        if (!gameEnded)
        {
            Debug.Log("You Loose!");
            gameEnded = true;
        }

    }
}
