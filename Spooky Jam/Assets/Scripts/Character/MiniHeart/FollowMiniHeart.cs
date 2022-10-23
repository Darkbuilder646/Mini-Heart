using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMiniHeart : MonoBehaviour
{
    [SerializeField] private Transform Player;
    private void Update()
    {
        transform.position = Player.transform.position;
    }
}
