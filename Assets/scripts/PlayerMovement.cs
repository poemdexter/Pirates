using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float speed; 
    public float pointingPower;
    
    Vector2 normalizedInputVector;
    Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        
        bool isWalking = (inputX != 0 || inputY != 0);
        animator.SetBool("isWalking", isWalking);
        
        normalizedInputVector = (new Vector2(inputX, inputY)).normalized;
        transform.Translate(normalizedInputVector.x * Time.deltaTime * speed, normalizedInputVector.y * Time.deltaTime * speed, 0);
    }
    
    public Vector3 GetPlayerPointingPosition()
    {
        return new Vector3(transform.position.x + (normalizedInputVector.x * pointingPower), transform.position.y + (normalizedInputVector.y * pointingPower), 0);
    }
}