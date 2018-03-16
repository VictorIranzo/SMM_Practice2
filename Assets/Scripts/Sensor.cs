using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Sensor : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject exit = GameObject.FindGameObjectsWithTag("Exit").FirstOrDefault();
        exit.transform.position = new Vector3(2,2,0);
    }
}
