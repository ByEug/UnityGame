using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    private Canvas canvas;

    public bool isActiveInventory = false;

    public GameObject player;

    public Canvas Console;

    public Slot[] slots;

    private void CheckItems()
    {
        if (player.GetComponent<Items>().CheckItem("Gun") != 0)
        {
            slots[0].GetGun();
        }
        slots[1].GetItem(player.GetComponent<Items>().CheckItem("AidKit"));
        slots[2].GetItem(player.GetComponent<Items>().CheckItem("EnergyBooster"));
    }

    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
        isActiveInventory = false;
        slots = canvas.GetComponentsInChildren<Slot>();
        CheckItems();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && Console.isActiveAndEnabled == false)
        {
            CheckItems();
            canvas.enabled = !canvas.enabled;
            if (isActiveInventory)
            {
                isActiveInventory = false;
                Time.timeScale = 1f;
            }
            else
            {
                isActiveInventory = true;
                Time.timeScale = 0f;
            }
            //player.SetActive(!player.activeInHierarchy);
        }

        if (Input.GetKeyDown(KeyCode.Escape) && canvas.enabled == true)
        {
            canvas.enabled = false;
            isActiveInventory = false;
            Time.timeScale = 1f;
            //player.SetActive(!player.activeInHierarchy);
        }

    }
    void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
