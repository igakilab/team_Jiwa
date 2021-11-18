using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip EneterTemp;
    private static AudioClip enterSound;
    private static AudioSource AudioSourceBGM;
    private static AudioSource AudioSourceSE;
    // Start is called before the first frame update

    public static void PlaySelectSound()
    {
        AudioSourceSE.PlayOneShot(enterSound);
    }
    void Start()
    {
        AudioSourceSE = transform.Find("SoundSE").GetComponent<AudioSource>();
        AudioSourceBGM = transform.Find("SoundBGM").GetComponent<AudioSource>();
        DontDestroyOnLoad(this);
    }

    private void Awake()
    {
        enterSound = EneterTemp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
