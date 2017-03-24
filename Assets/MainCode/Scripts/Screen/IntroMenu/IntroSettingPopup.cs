using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
public class IntroSettingPopup : MonoBehaviour
{
    [SerializeField]
    private tk2dUIScrollbar scrbSound;
    [SerializeField]
    private tk2dUIScrollbar scrbMusic;
    [SerializeField]
    private IntroScreenManager screenManager;
    void Start()
    {
        scrbMusic.SetScrollPercentWithoutEvent(Prefs.Instance.GetVolumeMusic());
        scrbSound.SetScrollPercentWithoutEvent(Prefs.Instance.GetVolumeSoundFx());
    }

    public void Close()
    {
        Prefs.Instance.SetVolumeMusic(MusicManager.Instance.volume);
        Prefs.Instance.SetVolumeSoundFx(SoundManager.Instance.volume);
        gameObject.SetActive(false);
    }

    public void UpdateSoundValue()
    {
        //scrbSound.Value = Mathf.Clamp(scrbSound.Value, 0, 1);
        SoundManager.Instance.SetVolume(scrbSound.Value);
    }

    public void UpdateMusicValue()
    {
        // scrbMusic.Value = Mathf.Clamp(scrbMusic.Value, 0, 1);
        MusicManager.Instance.volume = scrbSound.Value;
    }
}

