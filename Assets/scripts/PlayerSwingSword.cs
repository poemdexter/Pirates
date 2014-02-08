using UnityEngine;
using System.Collections;

public class PlayerSwingSword : MonoBehaviour
{
    public bool isSwinging = false;
    Quaternion startRotation;
    Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        if ((Input.GetButtonDown("Attack") || Input.GetAxis("Attack") < 0) && !isSwinging) {
            isSwinging = true;
            startRotation = transform.rotation;
            audio.Play();
        }
        
        if (isSwinging)
            animator.SetBool("isSwinging", true);
        else
            animator.SetBool("isSwinging", false);
    }
    
    void ResetSwordRotation()
    {
        transform.rotation = startRotation;
    }
}