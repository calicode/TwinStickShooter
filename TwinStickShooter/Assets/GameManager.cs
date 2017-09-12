using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour
{
    bool recording = true;




    public bool RecordingState()
    {
        return recording;

    }

    // Use this for initialization
    void Start()
    {

    }



    // Update is called once per frame
    void Update()
    {
        if (CrossPlatformInputManager.GetButton("Fire1") && recording)
        {
            recording = false;
            BroadcastMessage("PlayReplayFrames");

        }
        else
        {
            recording = true;
            BroadcastMessage("RecordReplayFrames");
        }

        Debug.Log("recording is" + recording);
    }
}
