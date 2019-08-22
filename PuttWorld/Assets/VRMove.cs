using UnityEngine;

public class VRMove : MonoBehaviour
{
    //public Transform rightController;
    //public GameObject leftController;

    private float _mMoveSpeed = 2.5f;
    private float _mHorizontalTurnSpeed = 180f;
    private float _mVerticalTurnSpeed = 2.5f;
    private bool _mInverted = false;

    public float sprintMultiplier = 1.5f;
    bool sprint = false;

    Vector3 movement;
    float horzTouchPad;
    float vertTouchPad;

    void Update()
    {
        horzTouchPad = Input.GetAxis("Horizontal");
        vertTouchPad = Input.GetAxis("Vertical");

        if (Input.GetAxis("LeftTrigger") > 0.2f)
        {
            sprintMultiplier = 1.5f;
        }
        else
        {
            sprintMultiplier = 1f;
        }
    }

    private void FixedUpdate()
    {
        //if (leftController != null)
        //{
        Quaternion orientation = Camera.main.transform.rotation;
        Vector3 moveDirection = orientation * Vector3.forward * vertTouchPad; // orientation * Vector3.forward * vertTouchPad
        Vector3 pos = transform.position;
        pos.x += moveDirection.x * _mMoveSpeed * Time.deltaTime * sprintMultiplier;
        pos.z += moveDirection.z * _mMoveSpeed * Time.deltaTime * sprintMultiplier;
        transform.position = pos;
        //}

        //if (rightController != null)
        //{
        if (horzTouchPad > 0.1f || horzTouchPad < -0.1f)
        {
            Vector3 euler = transform.rotation.eulerAngles;

            euler.y += horzTouchPad * _mHorizontalTurnSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(euler);
        }
        //}
    }
}