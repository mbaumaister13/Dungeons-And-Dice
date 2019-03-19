using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthText : MonoBehaviour
{
    TextMeshPro healthText;
    // Start is called before the first frame update
    void Start()
    {
        //healthText = GameObject.Find("UI_Manager").transform.Find("Health").gameObject.GetComponent<TextMeshPro>();
        healthText = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + Player.hp;
    }
}
