using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class RotationDetector : MonoBehaviour
{
    public float maxRotationThreshold = 1.0f; // Adjust the threshold value

    private AudioSource audioSource;

    void Start()
    {
        Input.gyro.enabled = true; // Enable the accelerometer

        // Get the AudioSource component from the same GameObject
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        Vector3 accelerometerData = Input.gyro.userAcceleration;

        // Check for excessive left or right rotation
        if (Mathf.Abs(accelerometerData.x) > maxRotationThreshold)
        {
            // Trigger the sound effect
            PlaySoundEffect();
        }
    }

    void PlaySoundEffect()
    {
        // Play the sound effect using the AudioSource component
        audioSource.Play();
    }
}
