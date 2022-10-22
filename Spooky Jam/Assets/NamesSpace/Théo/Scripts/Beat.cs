using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beat : MonoBehaviour
{
    [SerializeField] private GameObject particlePrefab;
    [SerializeField] private List<AudioClip> beatSound = new List<AudioClip>();
    [SerializeField] private float delay = 2;
    private bool isActive = false;

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
        Instantiate(particlePrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(delay);
        isActive = false;
    }



    /*
    //TODO : Préfab particule systeme
    //TODO : Init le préfab à chaque beats au coordonnée du joueur
    TODO : Play l'audio clip du beat 
    //TODO : destroy l'ancien beat avant d'en créer un nouveau
    */
}
