using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
[RequireComponent(typeof(ClockUtility))]
public class InputPipe : EntityFactory
{
    public Transform SpawnPoint;

    public List<GameObject> items = new List<GameObject>();

    private ClockUtility clock;


    // Start is called before the first frame update
    void Start()
    {
        clock = this.gameObject.GetComponent<ClockUtility>();
        clock.Action.AddListener(SpawnItem);
        //clock.StartClock();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnItem()
    {
        var Item = Instantiate(items[Random.Range(0,items.Count)], SpawnPoint.position, Quaternion.identity);
    }

    public override void Stop()
    {
        clock.Stop();
    }

    public override void Begin()
    {
        clock.StartClock();
    }
}
