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
    void FixedUpdate()
    {
        bool replayPressed = CrossPlatformInputManager.GetButton("Replay");

        if (replayPressed)
        {
            recording = false;
            BroadcastMessage("PlayReplayFrames");

        }
        else if (!replayPressed)
        {
            recording = true;
            BroadcastMessage("RecordReplayFrames");
        }

        Debug.Log("recording is" + recording);
    }
}
