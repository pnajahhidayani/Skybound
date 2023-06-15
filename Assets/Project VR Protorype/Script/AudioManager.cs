using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioClip engineSound;
    public AudioClip coinSound;
    public AudioClip explosionSound;
    public AudioClip boostSound;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    void PlayClip(AudioClip clip) {
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
    }

    public void PlayEngineSound(GameObject player) {
        player.AddComponent<AudioSource>();

        player.GetComponent<AudioSource>().clip = engineSound;
        player.GetComponent<AudioSource>().loop = true;
        player.GetComponent<AudioSource>().Play();
    }

    public void StopEngineSound(GameObject player) {
        player.GetComponent<AudioSource>().Stop();
    }

    public void PlayCoinSound() {
        PlayClip(coinSound);
    }

    public void PlayExplosionSound() {
        PlayClip(explosionSound);
    }

    public void PlayBoostSound() {
        PlayClip(boostSound);
    }
}