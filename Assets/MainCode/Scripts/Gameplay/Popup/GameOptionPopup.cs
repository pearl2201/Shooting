﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
public class GameOptionPopup : MonoBehaviour
{
    [SerializeField]
    private tk2dUIScrollbar scrbSound;
    [SerializeField]
    private tk2dUIScrollbar scrbMusic;
    [SerializeField]
    private GameManager gameManager;
    void Start()
    {
        scrbMusic.SetScrollPercentWithoutEvent(Prefs.Instance.GetVolumeMusic());
        scrbSound.SetScrollPercentWithoutEvent(Prefs.Instance.GetVolumeSoundFx());
    }

    public void Close()
    {
        gameManager.CloseOptionPopup();
    }

    public void UpdateSoundValue()

    {
       
        SoundManager.Instance.SaveVolumePreference(scrbSound.Value);
    }

    public void UpdateMusicValue()
    {
       
        MusicManager.Instance.SaveVolumePreference(scrbMusic.Value);
    }
}

