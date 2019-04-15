using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VendorManager : MonoBehaviour
{
    // Start is called before the first frame update

    Button h1, h2, h3, s1, s2, s3, exit;
    GameObject brokePanel;
    PlayerController player;
    void Start()
    {  
        player = PlayerManager.instance.player.GetComponent<PlayerController>();
        h1 = GetComponentInChildren<Canvas>().transform.Find("HealthCanvas").transform.Find("Option1Button").gameObject.GetComponent<Button>();
        h2 = GetComponentInChildren<Canvas>().transform.Find("HealthCanvas").transform.Find("Option2Button").gameObject.GetComponent<Button>();
        h3 = GetComponentInChildren<Canvas>().transform.Find("HealthCanvas").transform.Find("Option3Button").gameObject.GetComponent<Button>();
        s1 = GetComponentInChildren<Canvas>().transform.Find("StrengthCanvas").transform.Find("Option1Button").gameObject.GetComponent<Button>();
        s2 = GetComponentInChildren<Canvas>().transform.Find("StrengthCanvas").transform.Find("Option2Button").gameObject.GetComponent<Button>();
        s3 = GetComponentInChildren<Canvas>().transform.Find("StrengthCanvas").transform.Find("Option3Button").gameObject.GetComponent<Button>();
        exit = GetComponentInChildren<Canvas>().transform.Find("ExitButton").gameObject.GetComponent<Button>();
        brokePanel = GetComponentInChildren<Canvas>().transform.Find("BrokePanel").gameObject;
        brokePanel.SetActive(false);

        h1.onClick.AddListener(buy10HP);
        h2.onClick.AddListener(buy25HP);
        h3.onClick.AddListener(buy50HP);
        s1.onClick.AddListener(buy10str);
        s2.onClick.AddListener(buy25str);
        s3.onClick.AddListener(buy50str);
        exit.onClick.AddListener(close);
    }

    void close() {
        GetComponentInChildren<Canvas>().enabled = false;
    }
    bool checkGold(int gold) {
        if (player.gold < gold) {
            return false;
        }
        return true;
    }

    IEnumerator brokeShit() {
        brokePanel.SetActive(true);
        yield return new WaitForSecondsRealtime(3);
        brokePanel.SetActive(false);
    }
    // Update is called once per frame
    void buy10HP() {
        if (!checkGold(5)) {
            StartCoroutine(brokeShit());
        } else {
            player.gold -= 5;
            player.hp += 10;
        }
    }

    void buy25HP() {
        if (!checkGold(15)) {
            StartCoroutine(brokeShit());
        } else {
            player.gold -= 15;
            player.hp += 25;
        }
    }

    void buy50HP() {
        if (!checkGold(25)) {
            StartCoroutine(brokeShit());
        } else {
            player.gold -= 25;
            player.hp += 50;
        }
    }


    void buy10str() {
        if (!checkGold(5)) {
            StartCoroutine(brokeShit());
        } else {
            player.gold -= 5;
            player.strength += 0.1f;
        }
    }

    void buy25str() {
        if (!checkGold(15)) {
            StartCoroutine(brokeShit());
        } else {
            player.gold -= 15;
            player.strength += 0.25f;
        }
    }

    void buy50str() {
        if (!checkGold(25)) {
            StartCoroutine(brokeShit());
        } else {
            player.gold -= 25;
            player.strength += 0.5f;
        }
    }
}
