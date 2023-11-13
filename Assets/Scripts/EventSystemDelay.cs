using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemDelay : MonoBehaviour
{
    public float delayTime;
    public UnityEvent afterDelayEvent;
    private float afterDelay;

    // Start is called before the first frame update
    void Start()
    {
        afterDelay = Mathf.Infinity;
    }
    public void StartDelay()
    {
        afterDelay = Time.time + delayTime;
    }

    // Update is called once per frame
    void Update()
    {
       if(Time.time > afterDelay)
        {
            afterDelayEvent.Invoke();
            afterDelay = Mathf.Infinity;
        }
    }
}
