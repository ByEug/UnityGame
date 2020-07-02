using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Items : MonoBehaviour
{

    private Dictionary<string, int> items = new Dictionary<string, int>(5)
    {
        {"Gun", 0 },
        {"AidKit", 0 },
        {"Ammo", 0 },
        {"EnergyBooster", 0 },
        {"Money", 0 }
    };

    public void MakeItem(string key, int value)
    {
        items[key] = value;
    }

    public void AddItem(string key)
    {
        items[key] += 1;
    }

    public int CheckItem(string key)
    {
        return items[key];
    }

    public void DeleteItem(string key)
    {
        if (items[key] != 0)
        {
            items[key] -= 1;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
