using System.Collections;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    #region Variables
    public Sound[] sounds; //Array of sounds
    public static AudioManager instance;
    #endregion

    // Use this for initialization
    private void Awake()
    {

        //Check that there's only one AudioManager in the scene
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);

        //Make sure that the AudioManager doesn't get destroyed
        DontDestroyOnLoad(this.gameObject);

        //Creat an AudioSource for each sound
        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }
    }

    //Function that playes a sound based on the name given
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found !");
            return;
        }
        s.source.Play();
    }

    //Function that playes a sound based on the name given with a random pitch
    public void PlayWithRandomPitch(string name, float min, float max)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found !");
            return;
        }

        s.source.pitch = UnityEngine.Random.Range(min, max);
        s.source.Play();
    }

    public void Pause(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found !");
            return;
        }
        s.source.Pause();
    }
}
