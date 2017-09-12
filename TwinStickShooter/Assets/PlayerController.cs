using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class PlayerController : MonoBehaviour
{
    Vector3 playerMoveVector;
    [SerializeField]
    int moveSpeedDivisor = 5;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = CrossPlatformInputManager.GetAxis("Horizontal");
        playerMoveVector = new Vector3(transform.position.x, transform.position.y, transform.position.z + (horizontalMovement / moveSpeedDivisor));
        transform.position = playerMoveVector;
    }
}
