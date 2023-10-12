using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGoal : MonoBehaviour
{
    public WinLoose winLooseScript;

    private void OnTriggerEnter(Collider other)
    {

        winLooseScript.WinLevel();

    }
}
