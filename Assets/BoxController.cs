using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public static int damage = 30;
    public int maxHealth = 90;
    public int currentHealth;

    public Rigidbody2D rb;

    public GameObject Note_prefab;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 90;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            currentHealth -= damage;
        }
        if (currentHealth <= 0)
        {
            //GameObject Note = Instantiate(Note_prefab, rb.gameObject.transform.position, rb.gameObject.transform.rotation);
            Destroy(rb.gameObject);
        }
    }
}
