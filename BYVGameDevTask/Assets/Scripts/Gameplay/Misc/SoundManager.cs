using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip bulletRicochet;
    public static AudioClip shot;
    public static AudioClip gettingShot;
    public static AudioClip explosion;

    static AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        bulletRicochet = Resources.Load<AudioClip>("BulletRicochet");
        shot = Resources.Load<AudioClip>("Gunshot");
        gettingShot = Resources.Load<AudioClip>("GettingHit");
        explosion = Resources.Load<AudioClip>("Explosion");
        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Gunshot":
                audioSource.PlayOneShot(shot);
                break;
            case "BulletRicochet":
                audioSource.PlayOneShot(bulletRicochet);
                break;
            case "GettingHit":
                audioSource.PlayOneShot(gettingShot);
                break;
            case "Explosion":
                audioSource.PlayOneShot(explosion);
                break;
        }
    }
}
