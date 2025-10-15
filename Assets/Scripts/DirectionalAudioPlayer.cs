using UnityEngine;

/// <summary>
/// This script allows a GameObject to play an audio clip as a directional (3D) sound.
/// It requires an AudioSource component on the same GameObject.
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class DirectionalAudioPlayer : MonoBehaviour
{
    // The sound file (MP3, WAV, etc.) to be played.
    // You can drag and drop your audio file onto this field in the Unity Inspector.
    public AudioClip soundClip;

    // If true, the sound will start playing as soon as the scene loads.
    [Tooltip("If true, the sound will start playing as soon as the scene loads.")]
    public bool playOnStart = true;

    // If true, the sound will loop continuously.
    [Tooltip("If true, the sound will loop continuously.")]
    public bool loop = true;

    // A reference to the AudioSource component.
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        // Get the AudioSource component attached to this GameObject.
        audioSource = GetComponent<AudioSource>();

        // --- Configure the AudioSource for 3D Sound ---

        // Assign the audio clip to the AudioSource.
        audioSource.clip = soundClip;

        // Set the looping property from our public variable.
        audioSource.loop = loop;

        // Set the Spatial Blend to 1.0f to make the sound fully 3D.
        // A value of 0 would make it 2D (heard equally everywhere, like background music).
        // A value between 0 and 1 creates a mix of 2D and 3D.
        audioSource.spatialBlend = 1.0f;

        // You can also adjust other 3D sound settings here or in the Inspector, for example:
        // audioSource.rolloffMode = AudioRolloffMode.Logarithmic; // How the sound fades with distance.
        // audioSource.minDistance = 1f;    // The distance at which the sound starts to fade.
        // audioSource.maxDistance = 50f;   // The distance at which the sound is no longer audible.

        // If playOnStart is true, play the sound.
        if (playOnStart)
        {
            PlaySound();
        }
    }

    /// <summary>
    /// Plays the sound clip if it's not already playing.
    /// This can still be called from other scripts if you want to trigger the sound manually.
    /// </summary>
    public void PlaySound()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    /// <summary>
    /// Stops the sound clip.
    /// </summary>
    public void StopSound()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}

