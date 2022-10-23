using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioSelect : MonoBehaviour
{
    [SerializeField] private List<AudioClip> AllClips = new List<AudioClip>();
    [SerializeField] private Vector2 IntervalRandom = new Vector2(0, 5);
    private float CurrentTimer =0;

    private AudioSource CurrentAudioSource;
    private void Awake()
    {
        CurrentAudioSource = gameObject.GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (!CurrentAudioSource.isPlaying && CurrentTimer<=0)
        {
            CurrentAudioSource.clip = AllClips.GetRandom();
            CurrentAudioSource.Play();
            CurrentTimer = Random.Range(IntervalRandom.x, IntervalRandom.y);
        }
        CurrentTimer -= Time.deltaTime;
    }
}
