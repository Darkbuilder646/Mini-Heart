using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
using DG.Tweening;

public class Beat : MonoBehaviour
{
    [SerializeField] private GameObject particlePrefab;
    [SerializeField] private AudioClip simpleBeat;
    [SerializeField] private AudioClip fearBeat;
    [SerializeField] private AudioSource beatSound;
    [SerializeField] private float delay = 2;
    [SerializeField] private float t = 0;
    private bool isActive = false;
    private Vector3 StartScale;
    public bool inMonsterRange = false;

    private void Start()
    {
        StartScale = transform.localScale;
        StartCoroutine(PlayBeat());
    }
    private void Update() 
    {
        if (!isActive)
        {
            StartCoroutine(PlayBeat());
            t = Mathf.Clamp(t + Time.deltaTime *50, 0, 1.5f);
        }
    }

    [ContextMenu("Init Beat")]
    IEnumerator PlayBeat()
    {
        isActive = true;

        if(inMonsterRange)
        {
            beatSound.PlayOneShot(fearBeat);
            transform.DOKill(true);
            transform.DOPunchScale(new Vector3(0.25f, 0.25f, 0), 0.4f);
            yield return new WaitForSeconds(delay / (1.5f+t));
            isActive = false;
        }
        else
        {
            beatSound.PlayOneShot(simpleBeat);
            transform.DOKill(true);
            transform.DOPunchScale(new Vector3(0.15f, 0.15f, 0), 0.5f);
            yield return new WaitForSeconds(delay);
            isActive = false;
        }

        Instantiate(particlePrefab, transform.position, Quaternion.identity);
    }

    public void ChangeBeatMode(bool monsterBool)
    {
       inMonsterRange = monsterBool;
        t = 0;
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Monster"))
        {
            inMonsterRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Monster"))
        {
            inMonsterRange = false;
        }
    }

    /*
    //TODO : Préfab particule systeme
    //TODO : Init le préfab à chaque beats au coordonnée du joueur
    TODO : Play l'audio clip du beat 
    //TODO : destroy l'ancien beat avant d'en créer un nouveau
    */
}
