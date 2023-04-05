using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsController : MonoBehaviour
{

    public List<SoundType> SoundList = new List<SoundType>();
    private AudioSource Audio;
    public static SoundsController Instance;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Audio = GetComponent<AudioSource>();
    }
    public static void Play_Sound(string SoundName)
    {
        foreach(SoundType CurrSound in SoundsController.Instance.SoundList)
        {
            if(SoundName == CurrSound.SoundName)
            {
                AudioSource audio = Instance.Audio;
                audio.volume = CurrSound.AudioVolume;
                audio.PlayOneShot(CurrSound.SoundClip);
            }
            else
            {
                Debug.LogError("Cannot find audio source named:  " + SoundName);
            }
        }
    }
}
[System.Serializable]
public class SoundType
{
    public string SoundName = "Sound name";
    public AudioClip SoundClip;
    [Range(0.0f, 1.0f)]
    public float AudioVolume = 1;
}