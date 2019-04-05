using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : UIManager
{
    int maxHealth = 100;
    int currentHealth;
    Image healthBar;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
        DontDestroyOnLoad(healthBar);
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = player.hp;
        healthBar.fillAmount = currentHealth/maxHealth;
    }
}
