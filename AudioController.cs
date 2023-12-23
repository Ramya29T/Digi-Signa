using UnityEngine;
using UnityEngine.UI; // Include the UI namespace

public class AudioController : MonoBehaviour
{
    public AudioSource audioSource; // Assign this in the Inspector
    public Button muteButton; // Assign this in the Inspector
    public Sprite muteImage; // Assign this in the Inspector
    public Sprite unmuteImage; // Assign this in the Inspector

    private bool isMuted = false;

    public void ToggleSound()
    {
        isMuted = !isMuted;
        audioSource.mute = isMuted;

        // Change the button image
        if (isMuted)
        {
            muteButton.image.sprite = muteImage;
        }
        else
        {
            muteButton.image.sprite = unmuteImage;
        }
    }
}
