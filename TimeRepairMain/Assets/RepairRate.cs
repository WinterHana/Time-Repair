using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RepairRate : MonoBehaviour
{
    public static int score1 = 0;
    public static int bestscore = 0;
    // Start is called before the first frame update
    void Start()
    {
        score1 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = score1.ToString() + "/150";
    }
}
