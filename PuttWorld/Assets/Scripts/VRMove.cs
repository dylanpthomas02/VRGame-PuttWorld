using UnityEngine;

public class VRMove : MonoBehaviour
{
    private float _mMoveSpeed = 2.5f;
    private float _mHorizontalTurnSpeed = 180f;
    private float _mVerticalTurnSpeed = 2.5f;
    private bool _mInverted = false;

    public float sprintMultiplier = 1f;
    bool sprint = false;

    Vector3 movement;
    float strafeInput;
    float vertTouchPad;
    float horzRightPad;

    void Update()
    {
        strafeInput = Input.GetAxis("Strafe");
        vertTouchPad = Input.GetAxis("Forward");
        horzRightPad = Input.GetAxis("Turn");

        if (Input.GetAxis("LeftTrigger") > 0.2f)
            sprintMultiplier = 2f;
        else
            sprintMultiplier = 1f;
    }

    private void FixedUpdate()
    {
        Quaternion orientation = Camera.main.transform.rotation;
        //Vector3 strafing = orientation * Vector3.right * strafeInput;
        Vector3 moveDirection = orientation * Vector3.forward * vertTouchPad;

        Vector3 pos = transform.position;

        pos.x += moveDirection.x * _mMoveSpeed * Time.deltaTime * sprintMultiplier;
        pos.z += moveDirection.z * _mMoveSpeed * Time.deltaTime * sprintMultiplier;
        // apply movement to current position
        transform.position = pos;

        // include a dead zone so walking straight is easier
        if (horzRightPad > 0.1f || horzRightPad < -0.1f)
        {
            Vector3 euler = transform.rotation.eulerAngles;
            euler.y += horzRightPad * _mHorizontalTurnSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(euler);
        }
    }
}