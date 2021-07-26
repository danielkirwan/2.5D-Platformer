using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPanel : MonoBehaviour
{

    [SerializeField] MeshRenderer _lightColour;
    [SerializeField] private int _requiredCoins = 8;
    private Elevator _elevator;
    private bool _elevatorCalled = false;
    [SerializeField] private string _tagName;

    private void Start()
    {
        _elevator = GameObject.FindGameObjectWithTag(_tagName).GetComponent<Elevator>();
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
                    _elevatorCalled = false;
                }
                else
                {
                    StartCoroutine(ButtonPressed());
                    _elevatorCalled = true;
                }
                _elevator.CallElevator();
            }
        }
    }


    IEnumerator ButtonPressed()
    {
        _lightColour.material.color = Color.green;
        yield return new WaitForSeconds(2f);
        _lightColour.material.color = Color.red;
    }
}
