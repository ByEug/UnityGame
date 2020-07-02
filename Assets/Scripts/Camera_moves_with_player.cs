using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_moves_with_player : MonoBehaviour
{
    public Transform player;
    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
