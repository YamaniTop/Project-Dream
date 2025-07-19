using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerCollider : MonoBehaviour
{
    public UnityEvent Dead;
    public static bool keyGold;
    public GameObject KeyOne;
    public GameObject Rifle;

    private void Start()
    {
        keyGold = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject collisionObject = other.gameObject;

        if (collisionObject.CompareTag("death"))
        {
            Dead?.Invoke();
            Time.timeScale = 0f;
        }
        if (collisionObject.CompareTag("reflect"))
        {
            Dead?.Invoke();
            Time.timeScale = 0f;
        }
        if (collisionObject.CompareTag("Assault Rifle"))
        {
            ArmControllerRifle.isCollect = true;
            Destroy(Rifle);
            
        }
        if (collisionObject.CompareTag("KeyGold"))
        {
            
            keyGold = true;
        }


    }
}
