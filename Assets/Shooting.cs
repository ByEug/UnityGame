using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;

    public GameObject bulletPrefab;

    public GameObject Player;

    public Sprite mySprite;

    public float bulletSpeed = 20f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && (Player.GetComponent<SpriteRenderer>().sprite != mySprite) && Time.timeScale != 0f)
        {
            Shoot();
            AudioController.PlayAudio("shotgun");
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
    }
}
