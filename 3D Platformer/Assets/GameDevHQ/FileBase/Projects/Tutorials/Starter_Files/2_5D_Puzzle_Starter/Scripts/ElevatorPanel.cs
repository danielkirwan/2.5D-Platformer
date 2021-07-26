using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPanel : MonoBehaviour
{

    [SerializeField] MeshRenderer _lightColour;
    [SerializeField] private int _requiredCoins = 8;
    private Elevator _elevator;
    private bool _elevatorCalled = false;

    private void Start()
    {
        _elevator = GameObject.FindGameObjectWithTag("Elevator").GetComponent<Elevator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.P) && other.GetComponent<Player>().ReturnCoins() >= _requiredCoins )
            {
                Debug.Log("P key pressed");

                if (_elevatorCalled)
                {
                    _lightColour.material.color = Color.red;
                }
                else
                {
                    _lightColour.material.color = Color.green;
                    _elevatorCalled = true;
                }
                _elevator.CallElevator();
            }
        }
    }
}
