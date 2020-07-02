using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour, IMovableObject, IObservable
{
    public static bool serialization = false;
    public static PlayerDataToSave data;

    public static float time = 0f;

    public float moveSpeed;
    public int maxHealth;
    public static int currentHealth;
    public static int kills = 0;
    public static Transform PlayerPosition;
    public static Vector2 PlayerPosition2D;
    public float curr_time;

    public static List<IObserver> observers;

    public Sprite PlayerSprite;

    public GameObject player;

    public GameObject deathZ_Prefab;

    public GameObject inventory_canvas;

    public Slot[] slots;

    public Health_bar healthBar;

    public Rigidbody2D rb;
    public Camera cam;

    Vector2 movement;
    Vector2 mousePos;

    public void NotifyObservers()
    {
        foreach (IObserver o in observers)
        {
            o.UpdateInfo(player);
        }
    }
    public void RemoveObserver(IObserver item)
    {
        observers.Remove(item);
    }

    public void RegisterObserver(IObserver item)
    {
        observers.Add(item);
    }
    public static void UpHealth_Console()
    {
        currentHealth = 100;
    }
    public void UseEnergyBooster()
    {
        moveSpeed = 8f;
        curr_time = 15;

    }
    public void UseAidKit(int points)
    {
        currentHealth += points;
        if (currentHealth > 100)
        {
            currentHealth = 100;
        }
        healthBar.SetHealth(currentHealth);

    }
    public void CountTheAngle(Vector2 buffer)
    {
        float angle = Mathf.Atan2(buffer.y, buffer.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        slots = inventory_canvas.GetComponentsInChildren<Slot>();

        observers = new List<IObserver>();

        if (serialization)
        {
            Vector3 pos = new Vector3(data.position[0], data.position[1], data.position[2]);
            Quaternion rot = new Quaternion(data.rotation[0], data.rotation[1], data.rotation[2], 0f);

            player.GetComponent<Transform>().position = pos;
            player.GetComponent<Transform>().rotation = rot;
            currentHealth = data.CurrentHealth;
            time = data.time;
            kills = data.kills;
            player.GetComponent<Items>().MakeItem("AidKit", data.AidKitAmount);
            player.GetComponent<Items>().MakeItem("EnergyBooster", data.EnergyBoosterAmount);

            if (data.GunExists)
            {
                player.GetComponent<Items>().AddItem("Gun");
                player.GetComponent<SpriteRenderer>().sprite = PlayerSprite;
            }

            serialization = false;
        }
    }
    
    private void Update()
    {
        time += Time.deltaTime;

        healthBar.SetHealth(currentHealth);

        if (moveSpeed == 8f)
        {
            curr_time -= Time.deltaTime;
            if (curr_time <= 0)
            {
                moveSpeed = 3.5f;
            }
        }
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        PlayerPosition = this.transform;
        PlayerPosition2D = this.GetComponent<Rigidbody2D>().position;
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        NotifyObservers();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        CountTheAngle(lookDir);
        
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth > 0)
        {
            AudioController.PlayAudio("playerhit");
        }
        else
        {
            AudioController.PlayAudio("death");
            GameObject deathZ = Instantiate(deathZ_Prefab, rb.gameObject.transform.position, rb.gameObject.transform.rotation);
            Destroy(rb.gameObject);
            Rigidbody2D rigidbody = deathZ.GetComponent<Rigidbody2D>();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage(20);
        }
    }
}
