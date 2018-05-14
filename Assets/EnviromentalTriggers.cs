using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnviromentalTriggers : MonoBehaviour {

    public AudioClip forestTrack;
    public AudioClip beachTrack;
    public AudioClip canyonTrack;

    GameObject audHolder;
    AudioSource playerAudioSource;
   // Environment environment;

    GameObject FPC;

    // Use this for initialization
    void Start () {
        //FPC = gameObject.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        audHolder = GameObject.FindGameObjectWithTag("EnviromentAudioSource");
        playerAudioSource = audHolder.GetComponent<AudioSource>();
        playerAudioSource.loop = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        //var fps = gameObject.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        switch (other.name)
        {
           
            case ("Forest"):
               // fps.ChangeFootStepClip("Forest");
                playerAudioSource.clip = forestTrack;
                playerAudioSource.Play();
                break;
            case ("Beach"):
              //  fps.ChangeFootStepClip("Beach");
                playerAudioSource.clip = beachTrack;
                playerAudioSource.Play();
                break;
            case ("Canyon"):
               // fps.ChangeFootStepClip("Canyon");
                playerAudioSource.clip = canyonTrack;
                playerAudioSource.Play();
                break;

        }
    }
}

