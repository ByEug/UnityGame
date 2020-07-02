using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : AbstractItem
{
    public Sprite mySprite;

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
            if (obj.GetComponent<Items>().CheckItem("Gun") == 0)
            {
                obj.GetComponent<SpriteRenderer>().sprite = mySprite;
                obj.GetComponent<Items>().AddItem("Gun");
                obj.GetComponent<PlayerController>().slots[0].GetGun();
                Destroy(gameObject);
            }
        }
    }
}
