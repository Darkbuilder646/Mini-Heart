using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private float t = 0;
    [SerializeField] private float SpeedFade = 120;
    private bool IsDead = false;
    private void Start()
    {
        t = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        InputInterface input;
        if (collision.gameObject.TryGetComponent<InputInterface>(out input) 
            && collision.isTrigger == false) 
        {
            IsDead = true;
        }
    }

    private void Update()
    {
        if (IsDead)
        {
            t += Time.deltaTime * SpeedFade;
            Material m = gameObject.GetComponent<Renderer>().material;
            m.SetFloat("_Fade", t);
            if (t > 1)
            {
                Destroy(gameObject);
            }
        }
    }
}
