using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsSpawner : MonoBehaviour
{
    public GameObject gun_prefab;
    public GameObject zombie_prefab;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = new Vector3(-7.5f, -0.5f);
        Quaternion rot = new Quaternion(0, 0, 0, 0);
        GameObject new_gun = Instantiate(gun_prefab, pos, rot);

        /*Vector3 pos1 = new Vector3(2.5f, 3.5f);
        Quaternion rot1 = new Quaternion(0, 0, -180, 0);
        GameObject zomb1 = Instantiate(zombie_prefab, pos1, rot1);

        Vector3 pos2 = new Vector3(6.5f, -0.5f);
        Quaternion rot2 = new Quaternion(0, 0, -180, 0);
        GameObject zomb2 = Instantiate(zombie_prefab, pos2, rot2);

        Vector3 pos3 = new Vector3(-2.5f, -4.5f);
        Quaternion rot3 = new Quaternion(0, 0, 90, 0);
        GameObject zomb3 = Instantiate(zombie_prefab, pos3, rot3);*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
