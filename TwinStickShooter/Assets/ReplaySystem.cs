using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySystem : MonoBehaviour
{
    private const int BufferFrames = 100;
    private MyKeyFrame[] keyFrames = new MyKeyFrame[BufferFrames];
    private Rigidbody rigidbody;

    int currentReplayFrame = 0;

    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //RecordReplayFrames();


    }

    void PlayReplayFrames()
    {
        int frame = Time.frameCount % BufferFrames;
        rigidbody.isKinematic = true;


        transform.position = keyFrames[frame].myPosition;
        transform.rotation = keyFrames[frame].myRotation;
    }
    void RecordReplayFrames()
    {
        int frame = Time.frameCount % BufferFrames;
        rigidbody.isKinematic = false;


        keyFrames[frame] = new MyKeyFrame(Time.time, transform.position, transform.rotation);
    }

}

/// <summary>
/// A structure for storing time, rotation, and position.
/// </summary>
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