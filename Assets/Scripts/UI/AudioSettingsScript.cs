using UnityEngine;
using UnityEngine.UI;

public class AudioSettingsScript : MonoBehaviour
{
    public AudioSource audioSource;
    public static AudioSettingsScript AS;
    public Slider volumeSlider;
    public Toggle muteColtroler;
    public Text volumeValueText;
    // Use this for initialization
    private void Start()
    {
        if (AS == null)
        {
            AS = this;
        }
        else if (AS != this)
        {
            Destroy(gameObject);
        }
        volumeSlider.value = audioSource.volume * 1000;
        muteColtroler.isOn = audioSource.mute;
        ChangeVolumeValue();
    }

    public void ChangeVolumeValue()
    {
        volumeValueText.text = (volumeSlider.value / 10).ToString();
        audioSource.volume = volumeSlider.value * 0.001f;
    }


    public void MuteCotrols()
    {
        audioSource.mute = muteColtroler.isOn;
    }
}
