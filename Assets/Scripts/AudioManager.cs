using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class AudioManager : MonoBehaviour
{
    public static AudioManager I;

    [Header("Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Mixer (optional)")]
    public AudioMixer mixer;

    void Awake()
    {
        if (I != null && I != this) { Destroy(gameObject); return; }
        I = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PlayMusic(AudioClip clip, float fade = 0.5f)
    {
        if (clip == null) return;
        StopAllCoroutines();
        StartCoroutine(FadeInMusic(clip, fade));
    }

    IEnumerator FadeInMusic(AudioClip clip, float fade)
    {
        float startVol = musicSource.volume;
        for (float t = 0; t < fade; t += Time.unscaledDeltaTime)
        {
            musicSource.volume = Mathf.Lerp(startVol, 0f, t / fade);
            yield return null;
        }
        musicSource.volume = 0f;

        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();

        for (float t = 0; t < fade; t += Time.unscaledDeltaTime)
        {
            musicSource.volume = Mathf.Lerp(0f, 1f, t / fade);
            yield return null;
        }
        musicSource.volume = 1f;
    }

    public void StopMusic(float fade = 0.5f)
    {
        StartCoroutine(FadeOutMusic(fade));
    }

    IEnumerator FadeOutMusic(float fade)
    {
        float startVol = musicSource.volume;
        for (float t = 0; t < fade; t += Time.unscaledDeltaTime)
        {
            musicSource.volume = Mathf.Lerp(startVol, 0f, t / fade);
            yield return null;
        }
        musicSource.Stop();
        musicSource.volume = startVol;
    }

    public void PlaySFX(AudioClip clip, float volume = 1f)
    {
        if (clip == null) return;
        sfxSource.PlayOneShot(clip, volume);
    }

    public void PlaySFXVaried(AudioClip clip, float volume = 1f, float pitchJitter = 0.08f)
    {
        if (clip == null) return;
        float oldPitch = sfxSource.pitch;
        sfxSource.pitch = 1f + Random.Range(-pitchJitter, pitchJitter);
        sfxSource.PlayOneShot(clip, volume);
        sfxSource.pitch = oldPitch;
    }

    public void SetMusicVolume(float sliderValue)
    {
        if (mixer == null) { musicSource.volume = sliderValue; return; }
        mixer.SetFloat("MusicVol", sliderValue > 0 ? Mathf.Log10(sliderValue) * 20f : -80f);
    }

    public void SetSFXVolume(float sliderValue)
    {
        if (mixer == null) { sfxSource.volume = sliderValue; return; }
        mixer.SetFloat("SFXVol", sliderValue > 0 ? Mathf.Log10(sliderValue) * 20f : -80f);
    }
}
