using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreViewer : MonoBehaviour
{
    public List<Material> mat_State = new List<Material>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    public void SetClampedPosition(Vector3 position, Vector3 clamp,Vector3 offset)
    {
        var x = Mathf.Round(position.x * (1/clamp.x)) * clamp.x;
        var y = Mathf.Round(position.y * (1/clamp.y)) * clamp.y;
        var z = Mathf.Round(position.z * (1/clamp.z)) * clamp.z;

        var v = new Vector3(x,y,z) + offset;

        transform.position = v;
    }
}
