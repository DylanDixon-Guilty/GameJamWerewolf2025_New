using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// AudioManager handles audio settings and playback in the game.
/// </summary>


public enum eMixers { master, music, effects }

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [NamedArray(typeof(eMixers))] public AudioMixerGroup[] mixers;
    [NamedArray(typeof(eMixers))] public float[] volume = { 1f, 1f, 1f };
    [NamedArray(typeof(eMixers))] private string[] strMixers = { "MasterVolume", "MusicVolume", "EffectsVolume" };

    [SerializeField] private AudioSource BGM;
    [SerializeField] private AudioSource selection;
    //[SerializeField] private AudioSource eat;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.Log("Destroy New Audio Manager");
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void SetMixerLevel (eMixers _mixer, float _soundLevel)
    {
        mixers[(int)_mixer].audioMixer.SetFloat(strMixers[(int)_mixer], Mathf.Log10(_soundLevel) * 20f);
        volume[(int)_mixer] = _soundLevel;
    }

    public void PlaySelectAudio()
    {
        selection.Play();
    }

    public void PlayEatAudio()
    {
        //eat.Play();
    }

    public void PlayMoveAudio()
    {
        //move.Play();
    }

}
