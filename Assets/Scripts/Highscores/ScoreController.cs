using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public Text Time;
    public Text Name;
    public Text Kills;

    public void MakeText(float time, string name, int kills)
    {
        Time.text = time.ToString();
        Name.text = name;
        Kills.text = kills.ToString();
    }

    public void MakeClear()
    {
        Time.text = "";
        Name.text = "";
        Kills.text = "";
    }
}
