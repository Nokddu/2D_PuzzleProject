using UnityEngine;
using System.Collections.Generic;
using Utils.Management;


[System.Serializable]
public class SoundData
{
    public string key;
    public AudioClip clip;
}

public class SoundManager : SingletonGameObject<SoundManager>
{

    [SerializeField] private AudioSource audioSource = null;
    [SerializeField] private List<SoundData> sounds = new List<SoundData>();

    private Dictionary<string, AudioClip> soundDic;

    protected override void Awake()
    {
        base.Awake();

        soundDic = new Dictionary<string, AudioClip>();
        foreach (var sound in sounds)
        {
            if (!soundDic.ContainsKey(sound.key))
                soundDic.Add(sound.key, sound.clip);
        }
    }

    public void PlaySound(string key)
    {
        if (soundDic.ContainsKey(key))
            audioSource.PlayOneShot(soundDic[key]);
        else
            Debug.Log("사운드가 ");
    }
}
