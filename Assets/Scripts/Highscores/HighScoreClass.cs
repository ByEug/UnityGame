using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreClass
{
    public float timeInSeconds;
    public string Name;
    public int kills;

    public HighScoreClass()
    {

    }
    public HighScoreClass(float t, string n, int k)
    {
        timeInSeconds = t;
        Name = n;
        kills = k;
    }
}


public class HighScoreClassComparer : Comparer<HighScoreClass>
{
    public override int Compare(HighScoreClass obj1, HighScoreClass obj2)
    {
        if (obj1.timeInSeconds > obj2.timeInSeconds)
        {
            return 1;
        }
        else
        {
            if (obj1.timeInSeconds < obj2.timeInSeconds)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}

