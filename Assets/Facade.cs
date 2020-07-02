using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Facade
{
    private PlayerController PlayerContr;
    private Items items;

    public Facade(PlayerController o, Items c)
    {
        PlayerContr = o;
        items = c;
    }

    public void FacadeUseAidKit()
    {
        PlayerContr.UseAidKit(40);
        items.DeleteItem("AidKit");
    }

    public void FacadeUseEnergyBooster()
    {
        PlayerContr.UseEnergyBooster();
        items.DeleteItem("EnergyBooster");
    }
}
