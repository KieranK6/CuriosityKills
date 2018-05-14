using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeControls : MonoBehaviour {

    FMOD.Studio.Bus Master;
    FMOD.Studio.Bus SFX;
    FMOD.Studio.Bus Dialogue;
    FMOD.Studio.Bus Clue;
    FMOD.Studio.Bus Ambience;
    FMOD.Studio.Bus Movement;


    private void Awake()
    {
        Master = FMODUnity.RuntimeManager.GetBus("bus:/Master");
        SFX = FMODUnity.RuntimeManager.GetBus("bus:/Master/SFX");
        Dialogue = FMODUnity.RuntimeManager.GetBus("bus:/Master/Dialogue");
        Clue = FMODUnity.RuntimeManager.GetBus("bus:/Master/Clues");
        Ambience = FMODUnity.RuntimeManager.GetBus("bus:/Master/Ambience");
        Movement = FMODUnity.RuntimeManager.GetBus("bus:/Master/Player");


    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	

    public void MasterVolumeLevel(float newMasterVolume)
    {
        Master.setVolume(newMasterVolume);
    }

    public void SFXVolumeLevel(float newSFXVolume)
    {
        SFX.setVolume(newSFXVolume);
    }

    public void DialogueVolumeLevel(float newDialogueVolume)
    {
        Dialogue.setVolume(newDialogueVolume);
    }

    public void AmbienceVolumeLevel(float newAmbienceVolume)
    {
        Ambience.setVolume(newAmbienceVolume);
    }
    public void MovementVolumeLevel(float newMovementVolume)
    {
        Movement.setVolume(newMovementVolume);
    }
    public void ClueVolumeLevel(float newClueVolume)
    {
        Clue.setVolume(newClueVolume);
    }
}
