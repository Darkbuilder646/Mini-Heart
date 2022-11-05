using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    [SerializeField] private AudioSource heartSound;
    [SerializeField] private CanvasGroup fadeEnd;
    [SerializeField] private float duration = 2;

    private void Awake() 
    {
        fadeEnd.alpha = 0;
        heartSound.volume = 1;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            ActiveEndLevel();
        }
    }

    [ContextMenu("End Level")]
    void ActiveEndLevel()
    {
        Tween EndTween;
        EndTween = fadeEnd.DOFade(1, duration);
        EndTween = heartSound.DOFade(0, duration).OnComplete(()=> SceneManager.LoadSceneAsync("Main Menu", LoadSceneMode.Single));
    }
}
