using UnityEngine;

public class VRMove : MonoBehaviour
{
    public Transform rightController;
    public GameObject leftController;

    private float _mMoveSpeed = 2.5f;
    private float _mHorizontalTurnSpeed = 180f;
    private float _mVerticalTurnSpeed = 2.5f;
    private bool _mInverted = false;

    Vector3 movement;
    float horzTouchPad;
    float vertTouchPad;

    void Update()
    {
        horzTouchPad = Input.GetAxis("Horizontal");
        vertTouchPad = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        movement = new Vector3(horzTouchPad, 0f, vertTouchPad);

        if (null != leftController)
        {
            Quaternion orientation = Camera.main.transform.rotation;
            Vector3 moveDirection = orientation * Vector3.forward * vertTouchPad; // + orientation * Vector3.right * touchPadVector.x
            Vector3 pos = transform.position;
            pos.x += moveDirection.x * _mMoveSpeed * Time.deltaTime;
            pos.z += moveDirection.z * _mMoveSpeed * Time.deltaTime;
            transform.position = pos;
        }

        if (null != rightController)
        {
            Quaternion orientation = transform.rotation;

            Vector3 euler = transform.rotation.eulerAngles;

            //euler.x = Mathf.LerpAngle(euler.x, angle, _mVerticalTurnSpeed * Time.deltaTime);
            euler.y += horzTouchPad * _mHorizontalTurnSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(euler);
        }
    }
}