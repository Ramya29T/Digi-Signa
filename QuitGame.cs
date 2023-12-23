using UnityEngine;

public class GameControls : MonoBehaviour
{
    // Call this method to quit the game
    public void QuitGame()
    {
        // Quit the application
        Application.Quit();

        // If we're running in the Unity editor
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stop playing the scene
        #endif
    }
}
