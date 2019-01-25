using UnityEngine;
/// <summary>
/// Sets the audio of the game.
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [HideInInspector] public AudioSource audioSource;

    private void PersistentAudioManager()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else if (this != Instance)
        {
            Destroy(gameObject);
        }
    }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        PersistentAudioManager();

        audioSource.volume = GlobalSettings.controller;
    }
}
