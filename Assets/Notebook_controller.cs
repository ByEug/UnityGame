using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notebook_controller : MonoBehaviour
{
    public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.gameObject.tag == "Player")
        {
            Time.timeScale = 0f;
            canvas.enabled = true;
            canvas.GetComponent<CanvasDoneController>().EnterFields(PlayerController.time, PlayerController.kills);
        }
    }
}
