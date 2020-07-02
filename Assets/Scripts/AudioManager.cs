using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    public AudioSource flagSource;
    [SerializeField]
    private AudioClip flagClip, winClip;
    [SerializeField]
    private AudioSource _backgroundSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayFlagAudio()
    {
        flagSource.PlayOneShot(flagClip);
        _backgroundSource.Stop();
    }
    public void PlayWinAudio()
    {
        flagSource.PlayOneShot(winClip);
    }
}
