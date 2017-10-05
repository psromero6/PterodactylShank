using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip die, gameOver, gameWin, explosion;
    AudioSource source;
    // Use this for initialization
    void Start()
    {
        source = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Die()
    {
        source.PlayOneShot(die);
    }
    public void Explode()
    {
        source.PlayOneShot(explosion);
    }
    public void StopAllMusic()
    {
        source.Stop();
    }

    public void PlayGameOverMusic()
    {
        source.clip = gameOver;
        source.Play();
    }

    public void PlayGameWinMusic()
    {
        source.clip = gameWin;
        source.loop = false;
        source.Play();
    }
}
