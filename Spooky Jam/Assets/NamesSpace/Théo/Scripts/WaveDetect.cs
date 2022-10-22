using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveDetect : MonoBehaviour
{
    private EnnemiWave ennemiWaveScript;

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("test particule");
        if(other.TryGetComponent<EnnemiWave>(out ennemiWaveScript))
        ennemiWaveScript.StartWave();
        Debug.Log("Collider : " + other.name);
    }

}
