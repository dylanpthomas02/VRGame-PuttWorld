using UnityEngine;

public class VRGrab : MonoBehaviour
{
    public GameObject controller;
    public string axisName;

    private float triggerState = 0;

    private bool holdingPutter = false;
    private GameObject putter = null;

    public Vector3 holdPosition = new Vector3(0, -0.025f, 0.03f);
    public Vector3 holdRotation = new Vector3(0, 180, 0);

    void Update()
    {
        triggerState = Input.GetAxis(axisName);
    }

    void Grab(GameObject obj)
    {
        holdingPutter = true;
        putter = obj;

        putter.transform.parent = transform;

        putter.transform.localPosition = holdPosition;
        putter.transform.localEulerAngles = holdRotation;
    }

    void Release(GameObject obj)
    {
        holdingPutter = false;
        putter = null;

        putter.transform.SetParent(null);

        Rigidbody rb = putter.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.useGravity = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Putter"))
        {
            if (triggerState > 0.5f && !holdingPutter)
            {
                Grab(other.gameObject);
            }
        }
    }
}