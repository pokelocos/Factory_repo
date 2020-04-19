using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantForce : MonoBehaviour
{
    public Transform pivot;
    public float force;
    private void OnTriggerStay(Collider other)
    {
        var rb = other.GetComponent<Rigidbody>();

        if(rb != null)
        {
            rb.AddForceAtPosition(this.transform.up * force * Time.deltaTime, pivot.position);
        }

    }
}
