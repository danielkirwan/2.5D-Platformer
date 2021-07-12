using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPanel : MonoBehaviour
{

    [SerializeField] MeshRenderer _lightColour;
    [SerializeField] private int _requiredCoins = 8;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.P) && other.GetComponent<Player>().ReturnCoins() >= _requiredCoins )
            {
                Debug.Log("P key pressed");
                _lightColour.material.color = Color.green;                 
            }
        }
    }
}
