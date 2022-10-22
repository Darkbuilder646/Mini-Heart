using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiWave : MonoBehaviour
{
    private ParticleSystem ennemiPartS;
    [SerializeField] private float delay = 2;
    private bool isActive = false;
    private void Awake()
    {
        ennemiPartS = GetComponent<ParticleSystem>();        
    }

    public void StartWave()
    {
        if(!isActive)
        {
            StartCoroutine(Wave());
        }
    }

    IEnumerator Wave()
    {
        isActive = true;
        ennemiPartS.Play();
        yield return new WaitForSeconds(delay);
        isActive = false;
    }
}
