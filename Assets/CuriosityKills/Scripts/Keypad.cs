using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Keypad : MonoBehaviour
{

    string curPassword = "";
    HashSet<string> currentPassword;
    public string input;
    HashSet<string> userInput;
    public bool onTrigger;
    public bool doorOpen = false;
    public bool keypadScreen;
    public Transform doorHinge;
    //AudioSource doorAudio;
    bool playOnce = false;
    bool letOut = false;


    AudioClue AudioClueScript;
    GameObject player;

    [FMODUnity.EventRef]
    public string dooropen;
    FMOD.Studio.EventInstance dooropenEvent;


    private IEnumerator coroutine;

    List<string> roundClips;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        AudioClueScript = player.GetComponent<AudioClue>();
        roundClips = AudioClueScript.roundClues;
        userInput = new HashSet<string>();
        currentPassword = new HashSet<string>();



        dooropenEvent = FMODUnity.RuntimeManager.CreateInstance(dooropen);

        foreach (string x in roundClips)
        {
            curPassword += x;
            currentPassword.Add(x);
        }
        Debug.Log("Cur password: " + curPassword);
    }

    void OnTriggerEnter(Collider other)
    {
        onTrigger = true;
    }

    void OnTriggerExit(Collider other)
    {
        onTrigger = false;
        keypadScreen = false;
        input = "";
        userInput.Clear();
    }

    void Update()
    {
        if (userInput.SetEquals(currentPassword))
        {
            doorOpen = true;
        }

        if (keypadScreen)
        {
            player.GetComponent<PlayerMove>().disableMovement = true;
            player.GetComponentInChildren<PlayerLook>().disableLook = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            //Escape
            if (Input.GetKeyDown(KeyCode.F))
            {
                player.GetComponent<PlayerMove>().disableMovement = false;
                player.GetComponentInChildren<PlayerLook>().disableLook = false;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                onTrigger = false;
                keypadScreen = false;
                //input = "";
            }
        }

        if (doorOpen)
        {
            var newRot = Quaternion.RotateTowards(doorHinge.rotation, Quaternion.Euler(-90.0f, 0.0f, 170.0f), Time.deltaTime * 80);
            doorHinge.rotation = newRot;
            player.GetComponent<PlayerMove>().disableMovement = false;
            player.GetComponentInChildren<PlayerLook>().disableLook = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            //play audio
            if (!playOnce)
            {
                FMODUnity.RuntimeManager.AttachInstanceToGameObject(dooropenEvent, doorHinge.GetComponent<Transform>(), doorHinge.GetComponent<Rigidbody>());
                dooropenEvent.start();
                playOnce = true;
            }
            coroutine = RestartGame();
            StartCoroutine(coroutine);

        }
    }

    IEnumerator RestartGame()
    {
        Debug.Log("Starting Restart");
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene(0);
    }
    

    void OnGUI()
    {
        if (!doorOpen)
        {
            if (onTrigger)
            {
                GUI.Box(new Rect((Screen.width / 2) - 100, Screen.height / 2, 350, 30), "Press 'E' to open keypad");
                

                if (Input.GetKeyDown(KeyCode.E))
                {
                    keypadScreen = true;
                    onTrigger = false;
                }
            }

            if (keypadScreen)
            {
                int offset = (Screen.width / 2) - 100;
                int yOffset = 200;
                GUI.Box(new Rect(0 + offset, 0 + yOffset, 320, 250), ""); //container
                GUI.Box(new Rect(5 + offset, 5 + yOffset, 310, 25), input);

                GUI.Box(new Rect(50, 50, 350, 30), "F to escape");

                if (GUI.Button(new Rect(5 + offset, 35 + yOffset, 100, 100), "A"))
                {
                    input = input + "A";
                    userInput.Add("A");
                }

                if (GUI.Button(new Rect(110 + offset, 35 + yOffset, 100, 100), "B"))
                {
                    input = input + "B";
                    userInput.Add("B");
                }

                if (GUI.Button(new Rect(215 + offset, 35 + yOffset, 100, 100), "C"))
                {
                    input = input + "C";
                    userInput.Add("C");
                }

                if (GUI.Button(new Rect(5 + offset, 140 + yOffset, 100, 100), "D"))
                {
                    input = input + "D";
                    userInput.Add("D");
                }

                if (GUI.Button(new Rect(110 + offset, 140 + yOffset, 100, 100), "E"))
                {
                    input = input + "E";
                    userInput.Add("E");
                }

                if (GUI.Button(new Rect(215 + offset, 140 + yOffset, 100, 100), "F"))
                {
                    input = input + "F";
                    userInput.Add("F");
                }
                if (GUI.Button(new Rect(110 + offset, 260 + yOffset, 100, 30), "Reset"))
                {
                    input = "";
                    userInput.Clear();
                }
            }
        }
    }
}
