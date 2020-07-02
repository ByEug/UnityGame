using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{

    private Facade facade;

    public Sprite gun_sprite;

    public Image icon;

    public Text counter;

    public GameObject player;

    private void Start()
    {
        facade = new Facade(player.GetComponent<PlayerController>(), player.GetComponent<Items>());
    }
    public void GetGun()
    {
        icon.sprite = gun_sprite;
    }

    public void GetItem(int count)
    {
        counter.text = "x" + count;
    }

    public void onClickAidKit()
    {
        int buffer = player.GetComponent<Items>().CheckItem("AidKit");

        if (buffer != 0)
        {
            facade.FacadeUseAidKit();
            counter.text = "x" + (buffer - 1);
        }
        
    }

    public void onClickEnergyBooster()
    {
        int buffer = player.GetComponent<Items>().CheckItem("EnergyBooster");
        
        if (buffer != 0)
        {
            facade.FacadeUseEnergyBooster();
            counter.text = "x" + (buffer - 1);
        }
        
    }

}
