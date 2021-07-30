using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePad : MonoBehaviour
{
    MeshRenderer _meshRenderer;

    private void Start()
    {
        _meshRenderer = GetComponentInChildren<MeshRenderer>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MoveableBox"))
        {
           float distance = Vector3.Distance( this.transform.position, other.transform.position);
            if(distance <= 0.05f)
            {
                Rigidbody box = GetComponent<Rigidbody>();
                if(box != null)
                {
                    box.isKinematic = true;
                }

                if(_meshRenderer != null)
                {
                    _meshRenderer.material.color = Color.green;
                }
                Destroy(this);
            }
        }
    }
}
