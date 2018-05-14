using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClue : MonoBehaviour
{
    public List<AudioClip> potentialClues;
    [HideInInspector] public List<string> roundClues;
    List<string> potentialroundClues;
    List<int> roundClues_int;

    [FMODUnity.EventRef]
    public string AInputClue;
    FMOD.Studio.EventInstance AClueEvent;

    [FMODUnity.EventRef]
    public string BInputClue;
    FMOD.Studio.EventInstance BClueEvent;

    [FMODUnity.EventRef]
    public string CInputClue;
    FMOD.Studio.EventInstance CClueEvent;

    [FMODUnity.EventRef]
    public string DInputClue;
    FMOD.Studio.EventInstance DClueEvent;

    [FMODUnity.EventRef]
    public string EInputClue;
    FMOD.Studio.EventInstance EClueEvent;

    [FMODUnity.EventRef]
    public string FInputClue;
    FMOD.Studio.EventInstance FClueEvent;

    public string curPassword;



    void Awake()
    {
        roundClues = new List<string>();

        Shuffler shuffler = new Shuffler();
        //roundClues_int = new List<int> { 0, 1, 2, 3, 4, 5 };
        potentialroundClues = new List<string> { "A", "B", "C", "D", "E", "F" };
        shuffler.Shuffle(potentialroundClues);

        for (int i = 0; i < 4; i++)
        {
            //get potential clue clip at i
            string toAdd = potentialroundClues[i];
            //add to round clues
            roundClues.Add(toAdd);
            curPassword += toAdd;

            Debug.Log("Adding " + toAdd + " at position :" + i);
        }
    }

    private void Start()
    {
        AClueEvent = FMODUnity.RuntimeManager.CreateInstance(AInputClue);
        BClueEvent = FMODUnity.RuntimeManager.CreateInstance(BInputClue);
        CClueEvent = FMODUnity.RuntimeManager.CreateInstance(CInputClue);
        DClueEvent = FMODUnity.RuntimeManager.CreateInstance(DInputClue);
        EClueEvent = FMODUnity.RuntimeManager.CreateInstance(EInputClue);
        FClueEvent = FMODUnity.RuntimeManager.CreateInstance(FInputClue);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "AudioClue")
        {
            switch (other.name)
            {
                case ("Que_1"):
                    string note1 = roundClues[0];
                    playClue(note1);
                    Debug.Log(note1);
                    break;

                case ("Que_2"):
                    string note2 = roundClues[1];
                    playClue(note2);
                    Debug.Log(note2);
                    break;

                case ("Que_3"):
                    string note3 = roundClues[2];
                    playClue(note3);
                    Debug.Log(note3);
                    break;

                case ("Que_4"):
                    string note4 = roundClues[3];
                    playClue(note4);
                    Debug.Log(note4);
                    break;

            }
        }
    }

    void playClue(string note1)
    {
        Debug.Log("Playing " + note1);
        if (note1 == "A")
        {
            AClueEvent.start();
        }
        else if (note1 == "B")
        {
            BClueEvent.start();
        }
        else if (note1 == "C")
        {
            CClueEvent.start();
        }
        else if (note1 == "D")
        {
            DClueEvent.start();
        }
        else if (note1 == "E")
        {
            EClueEvent.start();
        }
        else if (note1 == "F")
        {
            FClueEvent.start();
        }
    }
}



/// <summary>Used to shuffle collections.</summary>

public class Shuffler
{
    /// <summary>Creates the shuffler with a <see cref="MersenneTwister"/> as the random number generator.</summary>

    public Shuffler()
    {
        _rng = new System.Random();
    }

    /// <summary>Shuffles the specified array.</summary>
    /// <typeparam name="T">The type of the array elements.</typeparam>
    /// <param name="array">The array to shuffle.</param>

    public void Shuffle<T>(IList<T> array)
    {
        for (int n = array.Count; n > 1;)
        {
            int k = _rng.Next(n);
            --n;
            T temp = array[n];
            array[n] = array[k];
            array[k] = temp;
        }
    }

    private System.Random _rng;
}
