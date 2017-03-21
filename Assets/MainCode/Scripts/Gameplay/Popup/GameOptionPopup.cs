using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
public class GameOptionPopup : MonoBehaviour
{
    private tk2dUIScrollbar scrbSound;
    private tk2dUIScrollbar scrbMusic;

    void Start()
    {
        scrbMusic.Value = Prefs.Instance.GetVolumeMusic();
        scrbSound.Value = Prefs.Instance.GetVolumeSoundFx();
    }

    public void Close()
    {

    }

    public void UpdateSoundValue()

    {
        scrbSound.Value = Mathf.Clamp(scrbSound.Value, 0, 1);
        SoundManager.Instance.SaveVolumePreference(scrbSound.Value);
    }

    public void UpdateMusicValue()
    {
        scrbMusic.Value = Mathf.Clamp(scrbMusic.Value, 0, 1);
        SoundManager.Instance.SaveVolumePreference(scrbMusic.Value);
    }
}

