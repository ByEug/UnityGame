using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class HighScoreArrayList
{
    public static List<HighScoreClass> list = new List<HighScoreClass>();

    public static string path = Application.persistentDataPath + "/Highscores.txt";

    public static void LoadScoresToList()
    {
        try
        {
            StreamReader file = new StreamReader(path);

            while(!file.EndOfStream)
            {
                float time = float.Parse(file.ReadLine());
                string name = file.ReadLine();
                int kills = int.Parse(file.ReadLine());
                HighScoreClass buffer = new HighScoreClass(time, name, kills);
                list.Add(buffer);
            }

            file.Close();
            list.Sort(new HighScoreClassComparer());
        }
        catch
        {

        }
    }

    public static void DeleteScoresFromList()
    {
        list.Clear();
        StreamWriter file = new StreamWriter(path, false);
        file.Write("");
        file.Close();
    }

    public static void UploadFileFromList()
    {
        StreamWriter file = new StreamWriter(path, false);

        foreach (HighScoreClass o in list)
        {
            file.WriteLine(o.timeInSeconds.ToString());
            file.WriteLine(o.Name);
            file.WriteLine(o.kills.ToString());
        }
        list.Clear();
        file.Close();
    }
}
