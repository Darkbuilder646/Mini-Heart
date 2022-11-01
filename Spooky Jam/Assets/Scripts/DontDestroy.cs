using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    private bool IsOrigin = false;
    [SerializeField]  private int numberOfObjectDesired = 0;

    private void Reset()
    {
       numberOfObjectDesired = FindObjectsOfType<DontDestroy>().Length;
    }
    
    
    [ContextMenu("Test")]
    private void Test()
    {
        numberOfObjectDesired = FindObjectsOfType<DontDestroy>().Length;
    }
    private void Start()
    {
        Debug.Log(numberOfObjectDesired);
        if (FindObjectsOfType<DontDestroy>().Length > numberOfObjectDesired && !IsOrigin)
        {
            Destroy(this);
        }
        else
        {
            DontDestroyOnLoad(this);
            IsOrigin = true;
        }
    }
}
