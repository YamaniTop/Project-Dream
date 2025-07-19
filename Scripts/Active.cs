using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Active : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject panel;
    //public GameObject options;
    void Start()
    {
        panel.SetActive(false);
        //options.SetActive(false);
        
    }
}
