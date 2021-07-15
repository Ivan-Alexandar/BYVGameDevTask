using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip bulletRicochet;
    public static AudioClip shot;
    public static AudioClip gettingShot;

    static AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        bulletRicochet = Resources.Load<AudioClip>("BulletRicochet");
        shot = Resources.Load<AudioClip>("Gunshot");
        gettingShot = Resources.Load<AudioClip>("GettingHit");
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        }
    }
}
