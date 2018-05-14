using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverbZone : MonoBehaviour
{

    FMOD.Studio.Bus Reverb;
    float Volume = 20;
    bool InVerbZone;

    void Awake()
    {
        Reverb = FMODUnity.RuntimeManager.GetBus("bus:/Reverb");
    }

    void Update()
    {
        Reverb.setVolume(Volume);
        if (InVerbZone)
        {
            Volume = Mathf.Lerp(Volume, 1f, Time.deltaTime * 3f);
        }
        else
        {
            Volume = Mathf.Lerp(Volume, 0f, Time.deltaTime * 3f);
        }
    }

    void Start()
    {
        Volume = 0f;
    }

    void OnTriggerEnter(Collider col)
    {
        InVerbZone = true;
    }

    void OnTriggerExit(Collider col)
    {
        InVerbZone = false;
    }
}