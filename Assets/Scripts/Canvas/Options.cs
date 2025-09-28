using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider effectsSlider;

    private void Start()
    {
        masterSlider.value = AudioManager.Instance.volume[(int)eMixers.master];
        musicSlider.value = AudioManager.Instance.volume[(int)eMixers.music];
        effectsSlider.value = AudioManager.Instance.volume[(int)eMixers.effects];
    }

    public void OnMasterVolumeChanged(float _value)
    {
        AudioManager.Instance.SetMixerLevel(eMixers.master, _value);
    }

    public void OnMusicVolumeChanged (float _value)
    {
        AudioManager.Instance.SetMixerLevel(eMixers.music, _value);
    }

    public void OnEffectsVolumeChanged(float _value)
    {
        AudioManager.Instance.SetMixerLevel(eMixers.effects, _value);
    }

    public void OnBackClicked()
    {
        Debug.Log("Options Back Clicked");
        Destroy(this.gameObject);
    }
}
