using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggers : MonoBehaviour {

    [FMODUnity.EventRef]
    public string YouWake;
    FMOD.Studio.EventInstance YouWakeEvent;
    bool YouWakeBool = false;

    [FMODUnity.EventRef]
    public string YouNotice;
    FMOD.Studio.EventInstance YouNoticeEvent;
    bool YouNoticeBool = false;

    [FMODUnity.EventRef]
    public string AhBackIn;
    FMOD.Studio.EventInstance AhBackInEvent;
    int hits = 0;

    [FMODUnity.EventRef]
    public string Magnificant;
    FMOD.Studio.EventInstance MagnificantEvent;
    bool MagnificantBool = false;

    [FMODUnity.EventRef]
    public string IWonder;
    FMOD.Studio.EventInstance IWonderEvent;
    bool IWonderBool = false;

    [FMODUnity.EventRef]
    public string AhAForest;
    FMOD.Studio.EventInstance AhAForestEvent;
    bool AhAForestBool = false;

    [FMODUnity.EventRef]
    public string QuaintRiver;
    FMOD.Studio.EventInstance QuaintRiverEvent;
    bool QuaintRiverBool = false;

    [FMODUnity.EventRef]
    public string AtOneWith;
    FMOD.Studio.EventInstance AtOneWithEvent;
    bool AtOneWithBool = false;

    [FMODUnity.EventRef]
    public string WouldntGoThere;
    FMOD.Studio.EventInstance WouldntGoThereEvent;
    bool WouldntGoThereBool = false;

    [FMODUnity.EventRef]
    public string GetAway;
    FMOD.Studio.EventInstance GetAwayEvent;
    bool GetAwayBool = false;

    [FMODUnity.EventRef]
    public string LetsSee;
    FMOD.Studio.EventInstance LetsSeeEvent;
    bool LetsSeeBool = false;

    [FMODUnity.EventRef]
    public string StrangeSound;
    FMOD.Studio.EventInstance StrangeSoundEvent;
    int StrangeSoundHits = 0;

    [FMODUnity.EventRef]
    public string hmmCanYou;
    FMOD.Studio.EventInstance hmmCanYouEvent;
    int hmmCanYouHits = 0;

    [FMODUnity.EventRef]
    public string Win;
    FMOD.Studio.EventInstance WinEvent;
    bool WinBool = false;



    private void Awake()
    {
        YouWakeEvent = FMODUnity.RuntimeManager.CreateInstance(YouWake);
        YouNoticeEvent = FMODUnity.RuntimeManager.CreateInstance(YouNotice);
        AhBackInEvent = FMODUnity.RuntimeManager.CreateInstance(AhBackIn);
        MagnificantEvent = FMODUnity.RuntimeManager.CreateInstance(Magnificant);
        IWonderEvent = FMODUnity.RuntimeManager.CreateInstance(IWonder);
        AhAForestEvent = FMODUnity.RuntimeManager.CreateInstance(AhAForest);
        QuaintRiverEvent = FMODUnity.RuntimeManager.CreateInstance(QuaintRiver);
        AtOneWithEvent = FMODUnity.RuntimeManager.CreateInstance(AtOneWith);
        WouldntGoThereEvent = FMODUnity.RuntimeManager.CreateInstance(WouldntGoThere);
        GetAwayEvent = FMODUnity.RuntimeManager.CreateInstance(GetAway);
        LetsSeeEvent = FMODUnity.RuntimeManager.CreateInstance(LetsSee);
        WinEvent = FMODUnity.RuntimeManager.CreateInstance(Win);
        StrangeSoundEvent = FMODUnity.RuntimeManager.CreateInstance(StrangeSound);
        hmmCanYouEvent = FMODUnity.RuntimeManager.CreateInstance(hmmCanYou);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.name == "1_YouWake")
        {
            if(!YouWakeBool)
            {
                YouWakeEvent.start();
                YouWakeBool = true;
            }
            
        }

        else if (collision.name == "2_YouNoticeCave")
        {
            if (!YouNoticeBool)
            {
                YouNoticeEvent.start();
                YouNoticeBool = true;
            }
            
        }

        else if (collision.name == "3_AhFreshAir")
        {
            hits++;
            if(hits == 2)
            {
                AhBackInEvent.start();
            }
        }

        else if (collision.name == "4_Sea")
        {
            if (!MagnificantBool)
            {
                MagnificantEvent.start();
                MagnificantBool = true;
            }
        }

        else if (collision.name == "5_Passage")
        {
            if (!IWonderBool)
            {
                IWonderEvent.start();
                IWonderBool = true;
            }
        }

        else if (collision.name == "6_AhAForest")
        {
            if (!AhAForestBool)
            {
                AhAForestEvent.start();
                AhAForestBool = true;
            }
        }

        else if (collision.name == "7_QuaintRiver")
        {
            if (!QuaintRiverBool)
            {
                QuaintRiverEvent.start();
                QuaintRiverBool = true;
            }
        }

        else if (collision.name == "8_AtOneWithNature")
        {
            if (!AtOneWithBool)
            {
                AtOneWithEvent.start();
                AtOneWithBool = true;
            }
        }

        else if (collision.name == "9_WouldntGoThere")
        {
            if (!WouldntGoThereBool)
            {
                WouldntGoThereEvent.start();
                WouldntGoThereBool = true;
            }
        }

        else if (collision.name == "10_GetAway")
        {
            if (!GetAwayBool)
            {
                GetAwayEvent.start();
                GetAwayBool = true;
            }
        }

        else if (collision.name == "11_LetsSee")
        {
            if (!LetsSeeBool)
            {
                LetsSeeEvent.start();
                LetsSeeBool = true;
            }
        }

        else if (collision.name == "12_Win")
        {
            if (!WinBool)
            {
                WinEvent.start();
                WinBool = true;
            }
        }

        else if (collision.name == "13_StrangeSound")
        {
            StrangeSoundHits++;
            if (StrangeSoundHits == 2)
            {
                StrangeSoundEvent.start();
            }
        }

        else if (collision.name == "14_CanYou")
        {
            hmmCanYouHits++;
            if (hmmCanYouHits == 2)
            {
                hmmCanYouEvent.start();
            }
        }




    }
}
