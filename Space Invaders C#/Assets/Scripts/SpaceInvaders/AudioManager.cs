using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource killSource;
    public AudioSource shootSource;
    public AudioSource explosionSource;

    public static AudioSource kill;
    public static AudioSource shoot;
    public static AudioSource explosion;

    void Start()
    {
        kill = killSource;
        shoot = shootSource;
        explosion = explosionSource;
    }
		
    public static void PlayKill()
    {
        kill.Play(0);
    }

    public static void PlayShoot()
    {
        shoot.Play(0);
    }

    public static void PlayExplosion()
    {
        explosion.Play(0);
    }

}
