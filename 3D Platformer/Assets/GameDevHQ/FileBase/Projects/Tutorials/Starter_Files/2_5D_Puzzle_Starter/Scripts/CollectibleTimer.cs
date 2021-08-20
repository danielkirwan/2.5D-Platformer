using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleTimer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController player = other.GetComponent<PlayerController>();

            if (player != null)
            {
                Debug.Log("More Time added");
            }

            Destroy(this.gameObject);
        }
    }
}
