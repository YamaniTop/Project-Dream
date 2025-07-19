using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchPanel : MonoBehaviour
{
    public GameObject panelToSwitch;
    public static bool isPanelActive = false; 
    public float delay;

    void Start()
    {
        if (panelToSwitch != null)
        {
            panelToSwitch.SetActive(false); 
        }
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ActivatePanel();
        }

        
        if (Input.GetKeyUp(KeyCode.Q))
        {
            DeactivatePanel();
        }
    }

    
    void ActivatePanel()
    {
        if (panelToSwitch != null)
        {
            StartCoroutine(Delaying());
        }
    }


    void DeactivatePanel()
    {
        if (panelToSwitch != null)
        {
            Time.timeScale = 1.0f;
            panelToSwitch.SetActive(false);
            isPanelActive = false;
        }
    }
    IEnumerator Delaying()
    {
        panelToSwitch.SetActive(true);
        Time.timeScale = 0.2f;
        yield return new WaitForSeconds(delay);
        Time.timeScale = 1.0f;
    }

}