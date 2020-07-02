using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioClip ShotGun, Reload, StepInside, PlayerDeath, ZombieHit, PlayerHit;

    public static AudioSource audio_src;

    public static float volume = 1;
    // Start is called before the first frame update
    void Start()
    {
        ShotGun = Resources.Load<AudioClip>("shotgun");
        Reload = Resources.Load<AudioClip>("reload");
        PlayerDeath = Resources.Load<AudioClip>("death");
        ZombieHit = Resources.Load<AudioClip>("zhit2");
        PlayerHit = Resources.Load<AudioClip>("playerhit");
        //StepInside = Resources.Load<AudioClip>("stepinside");

        audio_src = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlayAudio(string clip)
    {
        switch(clip)
        {
            case "shotgun":
                {
                    audio_src.volume = volume;
                    audio_src.PlayOneShot(ShotGun);
                    break;
                }
            case "reload":
                {
                    audio_src.volume = volume;
                    audio_src.PlayOneShot(Reload);
                    break;
                }
            case "zhit2":
                {
                    audio_src.volume = volume;
                    audio_src.PlayOneShot(ZombieHit);
                    break;
                }
            case "death":
                {
                    audio_src.volume = volume;
                    audio_src.PlayOneShot(PlayerDeath);
                    break;
                }
            case "playerhit":
                {
                    audio_src.volume = volume;
                    audio_src.PlayOneShot(PlayerHit);
                    break;
                }
            /*case "stepinside":
                {
                    audio_src.PlayOneShot(StepInside);
                    break;
                }*/
        }
        
    }
}
