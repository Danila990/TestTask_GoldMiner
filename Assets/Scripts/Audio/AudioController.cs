using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AudioController : SingletonPersistent<AudioController>
{
    [SerializeField] private AudioClip _bomb;
    [SerializeField] private AudioClip _coin;
    [SerializeField] private AudioClip _buttonClick;
    [SerializeField] private AudioSource _audioSourceMusic;
    [SerializeField] private AudioSource _audioSourceSound;
    [SerializeField] private AudioSetting _audioSetting;

    public bool IsMusicMute => _audioSourceMusic.mute;
    public bool IsSoundMute => _audioSourceSound.mute;

    protected override void Awake()
    {
        base.Awake();

        _audioSourceMusic.mute = _audioSetting.IsMusicMute;
        _audioSourceSound.mute = _audioSetting.IsSoundMute;
    }

    public void ChangeMuteMusic(bool mute)
    {
        _audioSetting.IsMusicMute = mute;
        _audioSourceMusic.mute = mute;
    }

    public void ChangeMuteSound(bool mute)
    {
        _audioSetting.IsSoundMute = mute;
        _audioSourceSound.mute = mute;
    }

    public void PlayButtonClick()
    {
        _audioSourceSound.volume = 1f;
        _audioSourceSound.PlayOneShot(_buttonClick);
    }

    public void PlayCoin()
    {
        _audioSourceSound.volume = 0.1f;
        _audioSourceSound.PlayOneShot(_coin);
    }

    public void PlayBomb()
    {
        _audioSourceSound.volume = 0.1f;
        _audioSourceSound.PlayOneShot(_bomb);
    }
}

[CreateAssetMenu(fileName = "AudioSetting", menuName = "AudioSetting")]
public class AudioSetting : ScriptableObject
{
    public bool IsMusicMute = false;
    public bool IsSoundMute = false;
}
