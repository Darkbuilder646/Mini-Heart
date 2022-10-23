using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beat : MonoBehaviour
{
    [SerializeField] private GameObject particlePrefab;
    [SerializeField] private AudioClip simpleBeat;
    [SerializeField] private AudioClip fearBeat;
    [SerializeField] private AudioSource beatSound;
    [SerializeField] private float delay = 2;
    private bool isActive = false;
    public bool inMonsterRange = false;

    private void Start() 
    {
        StartCoroutine(PlayBeat());
    }
    private void Update() 
    {
        if(!isActive)
        {
            StartCoroutine(PlayBeat());
        }
    }

    [ContextMenu("Init Beat")]
    IEnumerator PlayBeat()
    {
        isActive = true;

        if(inMonsterRange)
        {
            Debug.Log("fear");
            beatSound.PlayOneShot(fearBeat);
            yield return new WaitForSeconds(delay / 1.5f);
            isActive = false;
        }
        else
        {
            Debug.Log("normal");
            beatSound.PlayOneShot(simpleBeat);
            yield return new WaitForSeconds(delay);
            isActive = false;
        }

        Instantiate(particlePrefab, transform.position, Quaternion.identity);
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
