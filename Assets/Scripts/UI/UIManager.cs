using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class UIManager : MonoBehaviour
{
    protected PlayerController player;
    public GameManager GM;
    public MusicManager MM;

    private Slider volume;

    void Start(){
        player = PlayerManager.instance.player.GetComponent<PlayerController>();
        volume = GameObject.Find("Volume").GetComponent<Slider>();
    }

    void Update() {
        if (Input.GetKeyDown("escape")) {
            GM.pause();
        }
    }

    public void volumeUpdate(float vol) {
        MM.SetVolume(vol);
    }

    public void toggleMusic(bool toggle) {
        volume.interactable = toggle;
        if (toggle == true) {
            MM.SetVolume(volume.value);
        } 
        else {
            MM.SetVolume(0f);
        }
    }
    public void Enable(string name){
        foreach(Transform t in transform){
            if(t.name == name){
                t.gameObject.SetActive(true);
            }
        }
    }
    public void Disable(string name){
        foreach(Transform t in transform){
            if(t.name == name){
                t.gameObject.SetActive(false);
            }
        }
    }
}
