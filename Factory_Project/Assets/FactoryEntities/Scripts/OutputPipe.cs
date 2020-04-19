using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputPipe : EntityFactory
{
    

    private void OnTriggerStay(Collider other)
    {
        //if(son cajas)
        {
            Destroy(other.gameObject);
        }
    }

    public override void Stop()
    {
        throw new System.NotImplementedException();
    }

    public override void Begin()
    {
        throw new System.NotImplementedException();
    }
}
