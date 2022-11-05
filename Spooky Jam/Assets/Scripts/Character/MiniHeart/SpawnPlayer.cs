using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] private Transform _transformSpawn = null;
    [SerializeField] private List<Checkpoints> AllChekpoints = new List<Checkpoints>();


    public Transform TransformSpawn { get => _transformSpawn; set => _transformSpawn = value; }
    void Start()
    {
        AllChekpoints.ForEach((c) =>
       {
           c.changeSpawn += AssignNewSpawn;
       });
        GameObject.FindObjectOfType<PlayerInput>().transform.position = _transformSpawn.position;
        SceneManager.sceneLoaded += delegate { CheckFinalScene(); };
    }
    public void CheckFinalScene()
    {
        if (SceneManager.GetActiveScene().name == "FinalScene")
            GameObject.FindObjectOfType<PlayerInput>().transform.position = _transformSpawn.position;
    }
    private void AssignNewSpawn(Transform t)
    {
        _transformSpawn = t;
    }
}
