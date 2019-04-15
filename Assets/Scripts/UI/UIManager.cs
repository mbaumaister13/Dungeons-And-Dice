using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{

    public GameManager GM;
    public MusicManager MM;

    private Slider volume;
    private Dropdown difficulty;

    void Start() {
        volume = GameObject.Find("Pause Menu").transform.Find("Music Settings").transform.Find("Volume").gameObject.GetComponent<Slider>();
        if (SceneManager.GetActiveScene().name == "StartScene") {
            difficulty = GameObject.Find("Pause Menu").transform.Find("Difficulty").transform.GetComponentInChildren<Dropdown>();
        }
    }


    void setDifficulty(string diff) {
        GameManager.difficult = diff;
    }
    void Update() {
        if (Input.GetKeyDown("escape")) {
            GM.pause();
        }
        if(difficulty!=null){
           setDifficulty(difficulty.captionText.text);
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
