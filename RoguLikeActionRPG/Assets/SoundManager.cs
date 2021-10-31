using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip EneterTemp;
    private static AudioClip enterSound;
    private static AudioSource audiosource;
    // Start is called before the first frame update

    public static void PlaySelectSound()
    {
        audiosource.PlayOneShot(enterSound);
    }
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
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
