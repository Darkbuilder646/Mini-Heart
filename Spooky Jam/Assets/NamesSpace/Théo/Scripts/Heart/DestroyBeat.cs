using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBeat : MonoBehaviour
{
    private ParticleSystem partS;

    private void Awake() 
    {
        partS = GetComponent<ParticleSystem>();   
    }
    void Update()
    {
        if(partS.isStopped)
        {
            Destroy(this.gameObject);
        }
    }
}
