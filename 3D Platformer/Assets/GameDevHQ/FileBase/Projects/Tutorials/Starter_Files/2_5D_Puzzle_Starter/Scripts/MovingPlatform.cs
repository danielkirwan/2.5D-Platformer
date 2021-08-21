using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform _targetA, _targetB;
    [SerializeField]
    private float _speed = 3.0f;
    private bool _switching = false;
    private bool _stopped = false;


    // Update is called once per frame
    void FixedUpdate()
    {
        if (!_switching && !_stopped)
        {

            transform.position = Vector3.MoveTowards(transform.position, _targetB.position, _speed * Time.fixedDeltaTime);
        }
        else if (_switching && !_stopped)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetA.position, _speed * Time.fixedDeltaTime);
        }

        if (transform.position == _targetB.position)
        {
            //_switching = true;
            StartCoroutine(WaitToMovePlatformTrue());
            _stopped = true;
        }
        else if (transform.position == _targetA.position)
        {
            //_switching = false;
            StartCoroutine(WaitToMovePlatformFalse());
            _stopped = true;
        }
    }

    IEnumerator WaitToMovePlatformTrue()
    {
        
        yield return new WaitForSeconds(3f);
        _switching = true;
        _stopped = false;
    }

    IEnumerator WaitToMovePlatformFalse()
    {
        
        yield return new WaitForSeconds(3f);
        _switching = false;
        _stopped = false;
    }


    //collison detection with player
    //if we collide with player
    //take the player parent = this game object
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = null;
        }
    }

    //exit collision 
    //check if the player exited
    //take the player parent = null 
}
