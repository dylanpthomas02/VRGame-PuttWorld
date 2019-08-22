using UnityEngine;

public class VRGrab : MonoBehaviour
{
    public string axisName;
    GameObject CollidingObject;
    GameObject grabbedObject;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInParent<VRGrabbable>())
        {
            CollidingObject = other.gameObject;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        CollidingObject = null;
    }

    void Update() 
    {
        if (Input.GetAxis(axisName) > 0.2f && CollidingObject)
        {
            GrabObject();
        }

        if (Input.GetAxis(axisName) < 0.2f && grabbedObject)
        {
            ReleaseObject();
        }
    }

    public void GrabObject() 
    {
        grabbedObject = CollidingObject;
        grabbedObject.transform.SetParent(gameObject.transform);
        VRGrabbable grabbable = grabbedObject.GetComponent<VRGrabbable>();
        grabbedObject.transform.SetPositionAndRotation(grabbable.snapOffset.localPosition,
            grabbable.snapOffset.localRotation);
        Rigidbody rb = grabbedObject.GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    private void ReleaseObject()
    {
        grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
        grabbedObject.transform.SetParent(null);
        grabbedObject = null;
    }
}