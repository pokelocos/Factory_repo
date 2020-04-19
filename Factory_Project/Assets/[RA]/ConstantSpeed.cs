using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantSpeed : MonoBehaviour
{
    public float speed;
    private void OnTriggerStay(Collider other)
    {
        other.transform.position = Vector3.MoveTowards(other.transform.position, other.transform.position + this.transform.forward, speed * Time.deltaTime);
    }
}
