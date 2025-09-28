using UnityEngine;

public class SelectionAudioCue : MonoBehaviour
{
    public void CueAudio()
    {
        AudioManager.Instance.PlaySelectAudio();
    }
}
