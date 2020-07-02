using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour, IMovableObject, IObserver
{

    private Vector2 playerPosition;

    public static int damage;

    public int maxHealth;
    public int currentHealth;
    public float moveSpeed;

    public Rigidbody2D rb;

    public GameObject deathZ_Prefab;
    public void UpdateInfo(GameObject ob)
    {
        playerPosition = ob.GetComponent<PlayerController>().transform.position;
    }

    public static void UpBulletDamage_Console()
    {
        damage = 60;
    }

    public void CountTheAngle(Vector2 buffer)
    {
        float angle = Mathf.Atan2(buffer.y, buffer.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }
    void Awake()
    {
        currentHealth = maxHealth;
        damage = 30;
    }

    void Start()
    {
        PlayerController.observers.Add(this);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPosition, moveSpeed * Time.deltaTime);
    }

    void FixedUpdate()
    {

        Vector2 lookDir = PlayerController.PlayerPosition2D - rb.position;
        CountTheAngle(lookDir);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            currentHealth -= damage;
            AudioController.PlayAudio("zhit2");
        }
        if (currentHealth <= 0)
        {
            AudioController.PlayAudio("zhit2");
            GameObject deathZ = Instantiate(deathZ_Prefab, rb.gameObject.transform.position, rb.gameObject.transform.rotation);
            PlayerController.observers.Remove(this);
            Destroy(rb.gameObject);
            Rigidbody2D rigidbody = deathZ.GetComponent<Rigidbody2D>();
            PlayerController.kills++;

        }
    }
}
