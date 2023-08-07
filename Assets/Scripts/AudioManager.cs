using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource audiosrc;
    public AudioMixerGroup mixerGroup;
    public Sound[] sounds;
    public Boolean isSoundPlaying;

    
    void Awake()
    {
        
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        foreach (Sound s in sounds)
        {
            audiosrc = s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop; 
            s.source.outputAudioMixerGroup = mixerGroup;
            isSoundPlaying = s.source.isPlaying;
        }
    }
    public void Play(string sound){
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + "not found");
            return;
        }
        s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
		s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));
        if(!s.source.isPlaying){
            s.source.Play();}
            else
            {
                return;
            }
    }
    public void Play2(string sound){
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + "not found");
            return;
        }
        s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
		s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));
        if(s.source.isPlaying){
            s.source.Play();}
            else
            {
                s.source.Play();
            }
    }
    public void Stop(string sound){
		Sound s = Array.Find(sounds, item => item.name == sound);
		s.source.volume = 0 * s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
		s.source.pitch = 0 * s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));
		s.source.Stop();
        
        
	}
    
    
    

}
