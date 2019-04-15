using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthText : MonoBehaviour
{
    TextMeshPro healthText;
    PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = PlayerManager.instance.player.GetComponent<PlayerController>();
        //strengthText = GameObject.Find("UI_Manager").transform.Find("Strength").gameObject.GetComponent<TextMeshPro>();
        healthText = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + player.hp + "HP";
    }
}
