using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityFactory : MonoBehaviour
{
    private int actual;
    public List<Vector3> orientations = new List<Vector3>();

    public abstract void Stop();
    public abstract void Begin();

    public void NextOrientation()
    {
        actual = (actual + 1) % orientations.Count;
        transform.rotation = Quaternion.Euler(orientations[actual]);
    }

}

