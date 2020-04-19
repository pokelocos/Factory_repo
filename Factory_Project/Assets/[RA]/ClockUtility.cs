using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// this elemente is a utility time counter.
/// </summary>
public class ClockUtility : MonoBehaviour
{
    public List<float> thresholds = new List<float>();

    private IEnumerator coroutine;
    public bool startOn = false;

    public UnityEvent Action;

    public void Start()
    {
        if (startOn) StartClock();
    }

    public void StartClock()
    {
        coroutine = Clock_thread(this);
        StartCoroutine(coroutine);
    }

    public void Stop()
    {
        StopCoroutine(coroutine);
        coroutine = null;
    }

    private IEnumerator Clock_thread(ClockUtility clock)
    {
        int i = 0;
        float time = 0;

        while(thresholds.Count > 0)
        {
            i = i % clock.thresholds.Count;
            
            if(time > clock.thresholds[i])
            {
                clock.Action.Invoke();
                time = 0;
                i++;
            }
            else
            {
                time += Time.deltaTime;
            }

            yield return new WaitForEndOfFrame();
        }
    }
}
