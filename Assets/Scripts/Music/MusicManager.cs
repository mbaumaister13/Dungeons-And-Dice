using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public void SetVolume(float vol) {
        GetComponent<AudioSource>().volume = vol;
        Debug.Log("Volume: " + vol);
    }

}
