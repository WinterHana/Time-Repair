using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class RepairRateScoreUp : MonoBehaviour
{
    bool follow = false;
    public static int a = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (follow && Input.GetKeyDown(KeyCode.LeftShift) && Score.score > 0)
        {
            GetComponent<AudioSource>().Play();
            RepairRate.score1 += 1;
            // this.gameObject.SetActive(false);
            Score.score -= 1;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        follow = true;
        a = 1;
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        follow = false;
        a = 0;
    }
}
