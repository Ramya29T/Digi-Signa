using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject CurrentPanel; // Assign the main menu panel in the Inspector
    public GameObject NextPanel; // Assign the level selection panel in the Inspector

    // Call this method when the Start button is clicked
    public void OnStartButtonClicked()
    {
        CurrentPanel.SetActive(false); // Disable the main menu panel
        NextPanel.SetActive(true); // Enable the level selection panel
    }
}
