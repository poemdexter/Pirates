using UnityEngine;
using System.Collections;

public class PlayerLookAt : MonoBehaviour
{
    Transform parent;
    Vector3 lookLeft, lookRight;
    GameController gc;
    
    void Start()
    {
        parent = transform.parent;
        lookLeft = new Vector3(-1, 1, 1);
        lookRight = new Vector3(1, 1, 1);
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
    
    void Update()
    {
        if (gc.IsUsingController())
            LookUsingController();
        else
            LookUsingMouse();
    }
    
    void LookUsingController()
    {
        float inputX = Input.GetAxis("Look X");
        float inputY = Input.GetAxis("Look Y");
        
        if (inputX < 0)
            parent.localScale = lookLeft;
        if (inputX > 0)
            parent.localScale = lookRight;
        
        float z = Mathf.Atan2(inputY, parent.localScale.x * inputX) * Mathf.Rad2Deg;
        
        // if we're looking left and no input, make sure we rotate completely so that sword is facing lefty forward
        if (parent.localScale == lookLeft && inputX + inputY == 0) {
            transform.eulerAngles = new Vector3(0, 0, 0);
        } else {
            transform.eulerAngles = new Vector3(0, 0, z);
        }
    }
    
    void LookUsingMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 input = mousePosition - transform.position;
        
        if (input.x < 0)
            parent.localScale = lookLeft;
        if (input.x > 0)
            parent.localScale = lookRight;
        
        float z = Mathf.Atan2(input.y, parent.localScale.x * input.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, z);
    }
}
