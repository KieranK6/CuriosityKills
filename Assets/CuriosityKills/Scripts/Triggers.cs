using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Triggers : MonoBehaviour {

    [FMODUnity.EventRef]
    public string rockslide;
    FMOD.Studio.EventInstance rockslideEvent;

    [FMODUnity.EventRef]
    public string branch;
    FMOD.Studio.EventInstance branchEvent;


    public GameObject rock;
    bool onceRockslide = false;

    

    private void Awake()
    {
        rockslideEvent = FMODUnity.RuntimeManager.CreateInstance(rockslide);
        branchEvent = FMODUnity.RuntimeManager.CreateInstance(branch);
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.name);
        if(collision.name == "Rockslide")
        {
            if (!onceRockslide)
            {
                onceRockslide = true;

                FMODUnity.RuntimeManager.AttachInstanceToGameObject(rockslideEvent, rock.GetComponent<Transform>(), rock.GetComponent<Rigidbody>());
                rockslideEvent.start();

                rock.GetComponent<Rigidbody>().useGravity = true;
                rock.GetComponent<Rigidbody>().AddForce(0, 20, 80);
                Debug.Log("Rock fall trigger");
            }
        }

        if (collision.tag == "Branch")
        {
            Debug.Log("Branch");
            int rand = Random.Range(1, 2);
            if(rand == 1)
            {
                FMODUnity.RuntimeManager.AttachInstanceToGameObject(branchEvent, GetComponent<Transform>(), GetComponent<Rigidbody>());
                branchEvent.start();
            }
        }

        if (collision.gameObject.name == "Rockslide_Rock")
        {
            if(collision.gameObject.GetComponent<Rigidbody>().velocity.magnitude > 0.4f)
                SceneManager.LoadScene(1);
        }
    }

 
}
