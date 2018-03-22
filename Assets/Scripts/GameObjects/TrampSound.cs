using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampSound : MonoBehaviour
{
    void playSound()
    {
        this.GetComponent<AudioSource>().Play();
    }
}