using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayerDataToSave
{

    public string SceneName;
    public int CurrentHealth;
    public float[] position;
    public float[] rotation;

    public float time;
    public int kills;

    public bool GunExists;
    public int AidKitAmount;
    public int EnergyBoosterAmount;

    public PlayerDataToSave()
    {

    }

    public PlayerDataToSave(GameObject player)
    {
        SceneName = SceneManager.GetActiveScene().name;
        CurrentHealth = PlayerController.currentHealth;
        time = PlayerController.time;
        kills = PlayerController.kills;
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
        rotation = new float[3];
        rotation[0] = player.transform.rotation.x;
        rotation[1] = player.transform.rotation.y;
        rotation[2] = player.transform.rotation.z;

        if (player.GetComponent<Items>().CheckItem("Gun") != 0)
        {
            GunExists = true;
        }
        else
        {
            GunExists = false;
        }

        AidKitAmount = player.GetComponent<Items>().CheckItem("AidKit");
        EnergyBoosterAmount = player.GetComponent<Items>().CheckItem("EnergyBooster");
    }
}
