using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AidKit : AbstractItem
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.transform.tag == "Player")
        {
            obj.GetComponent<Items>().AddItem("AidKit");
            int buffer = obj.GetComponent<Items>().CheckItem("AidKit");
            obj.GetComponent<PlayerController>().slots[1].GetItem(buffer);
            Destroy(gameObject);
        }
    }
}
