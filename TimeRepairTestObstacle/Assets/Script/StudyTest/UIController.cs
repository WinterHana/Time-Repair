using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject Panel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("��ư �Է�");
            Panel.SetActive(!(Panel.activeSelf));
        }
    }
}
