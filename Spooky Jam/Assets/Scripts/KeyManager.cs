using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> Keys = new List<GameObject>();
    [SerializeField] private List<GameObject> Doors = new List<GameObject>();
    [SerializeField] private GameObject RedKeyPrefab;
    [SerializeField] private GameObject BlueKeyprefab;
    private Vector3[] PositionKeys = new Vector3[0];
    private GameObject[,] KeysAndDoorsArray = new GameObject[0,0];
    private void Start()
    {
        PositionKeys = new Vector3[Keys.Count];
        KeysAndDoorsArray = new GameObject[Keys.Count, 2];
        for(int i = 0; i<Keys.Count; i++)
        {
            PositionKeys[i] = Keys[i].transform.position;
            KeysAndDoorsArray[i, 0] = Keys[i];
            KeysAndDoorsArray[i, 1] = Doors[i];
        }
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += delegate { CheckGenerateKey(); };
    }

    public void CheckGenerateKey()
    {
        for(int i = 0 ; i < Keys.Count; i++)
        {
           if(KeysAndDoorsArray[i,0] == null && KeysAndDoorsArray[i,1] != null) 
            {
                if(KeysAndDoorsArray[i, 1].tag == "RedDoor")
                {
                    Instantiate(RedKeyPrefab, PositionKeys[i], RedKeyPrefab.transform.rotation, KeysAndDoorsArray[i, 1].transform.parent);
                }
                else
                {
                    Instantiate(BlueKeyprefab, PositionKeys[i], BlueKeyprefab.transform.rotation, KeysAndDoorsArray[i, 1].transform.parent);
                }
            }
        }
    }
}
