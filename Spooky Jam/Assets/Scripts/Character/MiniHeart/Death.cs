using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    private float t = 0;
    [SerializeField] private float SpeedFade = 120;
    [SerializeField] private AudioSource heartSound;
    [SerializeField] private CanvasGroup fadeEnd;
    [SerializeField] private float duration = 2;
    private bool IsDead = false;
    private void Awake()
    {
        fadeEnd.alpha = 0;
        heartSound.volume = 1;
    }
    private void Start()
    {
        t = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        InputInterface input;
        if (collision.gameObject.TryGetComponent<InputInterface>(out input) 
            && collision.isTrigger == false) 
        {
            IsDead = true;
        }
    }

    private void Update()
    {
        if (IsDead)
        {
            t += Time.deltaTime * SpeedFade;
            Material m = gameObject.GetComponent<Renderer>().material;
            m.SetFloat("_Fade", t);
            if (t > 1)
            {
                ActiveEndLevel();

                gameObject.SetActive(false);
            }
        }
    }
    private void ActiveEndLevel()
    {
        Tween EndTween;
        EndTween = fadeEnd.DOFade(1, duration);
        EndTween = heartSound.DOFade(0, duration).OnComplete(() => SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name, LoadSceneMode.Single));
    }
}
