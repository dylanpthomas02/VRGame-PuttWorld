using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButton : MonoBehaviour
{
    public GameObject scorecard;
    public AudioSource source;
    Animator anim;
    bool setActive = false;

    private void Awake()
    {
        scorecard.SetActive(false);
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RightHand"))
        {
            setActive = !setActive;
            source.PlayOneShot(source.clip);
            ShowScorecard(setActive);
            anim.SetBool("isActive", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        anim.SetBool("isActive", false);
    }

    public void ShowScorecard(bool isActive)
    {
        scorecard.SetActive(isActive);
    }
}
