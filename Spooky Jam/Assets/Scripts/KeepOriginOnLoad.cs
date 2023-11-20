using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class KeepOriginOnLoad : MonoBehaviour
{
    private bool IsOrigin = false;
    private bool IsTheFirstLoad = true;
    private List<bool> ListOrigin = new List<bool>();
    private bool CanSave = false;
    [SerializeField,Tooltip("If \"All\" all the scene work")] private List<string> ChooseScene = new List<string>();
    public bool isOrigin { get => IsOrigin; set => IsOrigin = value; }

    private void CheckSceneDestroy()
    {
        CanSave = false;
        foreach (string s in ChooseScene)
        {
            if (s == "All")
            {
                CanSave = true;
                break;
            }
            if (SceneManager.GetActiveScene().name == s)
            {
                CanSave = true;
            }
        }
        if (!CanSave)
        {
            KeyManager k;
            if(gameObject.TryGetComponent<KeyManager>(out k))
            {
                SceneManager.sceneLoaded -= delegate { k.CheckGenerateKey(); };
            }
            SpawnPlayer s;
            if (gameObject.TryGetComponent<SpawnPlayer>(out s))
            {
                SceneManager.sceneLoaded -= delegate { s.CheckFinalScene(); };
            }
            SceneManager.sceneLoaded -= delegate { CheckSceneDestroy(); };
            Destroy(gameObject);
        }
    }
    private void Awake()
    {
        CheckSceneDestroy();


        SceneManager.sceneLoaded += delegate{CheckSceneDestroy();};

        foreach (KeepOriginOnLoad k in FindObjectsOfType<KeepOriginOnLoad>())
        {
            ListOrigin.Add(k.isOrigin);
        }
    }
    void Start()
    {
        foreach (bool o in ListOrigin)
        {
            if (o)
            {
                IsTheFirstLoad = false;
                break;
            }
        }
        if (IsTheFirstLoad == false && IsOrigin == false)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            IsOrigin = true;
        }
    }
}
