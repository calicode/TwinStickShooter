using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySystem : MonoBehaviour
{
    const int BufferFrames = 1000;
    MyKeyFrame[] keyFrames = new MyKeyFrame[BufferFrames];
    Rigidbody rb;

    [SerializeField]
    MyKeyFrame debugPlayBackFrame;


    [SerializeField]
    float frameTime;
    [SerializeField]
    int currentRecordingFrame = 0;
    [SerializeField]
    int currentReplayFrame = 0;
    int lastReplayFrameWithData;

    enum SystemStates { Replay, Recording };
    SystemStates currentState = SystemStates.Recording;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void PlayReplayFrames()
    {
        if (currentState != SystemStates.Replay)
        {
            Debug.Log("Setting currentreplay to 0");
            currentState = SystemStates.Replay;
            currentReplayFrame = 0;
            rb.isKinematic = true;
        }



        transform.rotation = keyFrames[currentReplayFrame].myRotation;
        transform.position = keyFrames[currentReplayFrame].myPosition;

        currentReplayFrame++;
        if (currentReplayFrame >= keyFrames.Length - 1 || keyFrames[currentReplayFrame].myTime == 0f)
        {

            Debug.Log("resetting replay frame");
            currentReplayFrame = 0;
        }


    }
    void RecordReplayFrames()
    {

        if (currentState != SystemStates.Recording)
        {

            currentState = SystemStates.Recording;
            keyFrames = new MyKeyFrame[BufferFrames]; // reset ring buffer 
            currentRecordingFrame = 0;

        }

        rb.isKinematic = false;
        keyFrames[currentRecordingFrame] = new MyKeyFrame(Time.time, transform.position, transform.rotation);

        if (currentRecordingFrame >= keyFrames.Length - 1) { currentRecordingFrame = 0; } else { currentRecordingFrame++; }
    }

}

/// <summary>
/// A structure for storing time, rotation, and position.
/// </summary>
[System.Serializable]
public struct MyKeyFrame
{
    public float myTime;
    public Vector3 myPosition;
    public Quaternion myRotation;

    public MyKeyFrame(float time, Vector3 pos, Quaternion rot)
    {
        myTime = time;
        myRotation = rot;
        myPosition = pos;

    }

}