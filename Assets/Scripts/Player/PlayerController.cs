using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //private bool hasCollidedWithWinCondition = false;


    private void OnTriggerEnter(Collider other)
    {
        // Check if the collision is with the "WinCondition" GameObject
        if (other.gameObject.CompareTag("MagicDoor"))
        {
            Debug.Log("done");
            // Set the flag to true when the player collides with the win condition
            //hasCollidedWithWinCondition = true;

            // Activate the win scene
            //SceneManager.LoadScene("GameController");

            // Disable the player GameObject
            gameObject.SetActive(false);
        }
    }
}