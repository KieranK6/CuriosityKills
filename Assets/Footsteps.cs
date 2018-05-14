using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{

    [FMODUnity.EventRef]
    public string InputFootsteps;
    FMOD.Studio.EventInstance FootstepsEvent;
    FMOD.Studio.ParameterInstance BeachParameter;
    FMOD.Studio.ParameterInstance CanyonParameter;
    FMOD.Studio.ParameterInstance ForestParameter;

    bool playerismoving;
    public float walkingspeed;
    private float BeachValue;
    private float CanyonValue;
    private float ForestValue;
    private bool playerisgrounded;

    void Start()
    {
        FootstepsEvent = FMODUnity.RuntimeManager.CreateInstance(InputFootsteps);
        FootstepsEvent.getParameter("Beach", out BeachParameter);
        FootstepsEvent.getParameter("Canyon", out CanyonParameter);
        FootstepsEvent.getParameter("Forest", out ForestParameter);

        InvokeRepeating("CallFootsteps", 0, walkingspeed);
    }

    void Update()
    {
        BeachParameter.setValue(BeachValue);
        CanyonParameter.setValue(CanyonValue);
        ForestParameter.setValue(ForestValue);

        if (Input.GetAxis("Vertical") >= 0.01f || Input.GetAxis("Horizontal") >= 0.01f || Input.GetAxis("Vertical") <= -0.01f || Input.GetAxis("Horizontal") <= -0.01f)
        {
            if (playerisgrounded == true)
            {
                playerismoving = true;
            }
            else if (playerisgrounded == false)
            {
                playerismoving = false;
            }
        }
        else if (Input.GetAxis("Vertical") == 0 || Input.GetAxis("Horizontal") == 0)
        {
            playerismoving = false;
        }
    }

    void CallFootsteps()
    {
        if (playerismoving == true)
        {
            FootstepsEvent.start();
        }
        else if (playerismoving == false)
        {
            //Debug.Log ("player is moving = false");
        }
    }

    void OnDisable()
    {
        playerismoving = false;
    }

    void OnTriggerStay(Collider MaterialCheck)
    {
        playerisgrounded = true;

        if (MaterialCheck.CompareTag("Env:Beach"))
        {
            BeachValue = 1f;
            CanyonValue = 0f;
            ForestValue = 0f;
        }
        if (MaterialCheck.CompareTag("Env:Canyon"))
        {
            BeachValue = 0f;
            CanyonValue = 1f;
            ForestValue = 0f;
        }
        if (MaterialCheck.CompareTag("Env:Forest"))
        {
            BeachValue = 0f;
            CanyonValue = 0f;
            ForestValue = 1f;
        }
    }

    void OnTriggerExit(Collider MaterialCheck)
    {
        playerisgrounded = false;
    }
}