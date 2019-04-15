using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class UIManager : MonoBehaviour
{

    public GameManager GM;
    public MusicManager MM;

    private Slider volume;

    void Start(){
        volume = GameObject.Find("Pause Menu").transform.Find("Music Settings").transform.Find("Volume").gameObject.GetComponent<Slider>();
    }

    void Update() {
        if (Input.GetKeyDown("escape")) {
            GM.pause();
        }
    }

    public void volumeUpdate(float vol) {
        MM.SetVolume(vol);
    }

    public void toggleMusic(bool isOn) {
        volume.interactable = isOn;
        MM.SetVolume(isOn ? volume.value : 0f);
        Debug.Log("Music Enabled: " + isOn);
    }

}
