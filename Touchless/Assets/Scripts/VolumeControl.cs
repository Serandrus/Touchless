using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// This class gets acces to the game volume and set it into a slider.
/// </summary>
public class VolumeControl : MonoBehaviour
{
    public Slider volume;

    private void Start()
    {
        if (GlobalSettings.controller == 0)
        {
            return;
        }

        volume.value = GlobalSettings.controller;
    }

    private void Update()
    {
        if (!volume) return;

        AudioManager.Instance.audioSource.volume = volume.value;
        GlobalSettings.controller = volume.value;
    }
}
