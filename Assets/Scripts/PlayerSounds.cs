using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField]
    public AudioClip[] footstepClips;
    public AudioClip hitSound;

    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Step()
    {
        AudioClip clip = GetRandomClip();
        audioSource.PlayOneShot(clip);
    }

    private void Hit ()
    {
        audioSource.PlayOneShot(hitSound);
    }

    private AudioClip GetRandomClip ()
    {
        return footstepClips[UnityEngine.Random.Range(0, footstepClips.Length)];
    }
}
