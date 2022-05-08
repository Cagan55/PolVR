using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSound : MonoBehaviour
{
    public AudioClip soundClip;
    public float soundLevel = 0.01f;
    AudioSource audio;
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        audio.PlayOneShot(soundClip, soundLevel);
    }
}
