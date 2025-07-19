using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorGold : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject collisionObject = other.gameObject;

        if (collisionObject.CompareTag("Player"))
        {
            if (PlayerCollider.keyGold == true)
            {
                Destroy(gameObject);
            }

        }
    }
}
