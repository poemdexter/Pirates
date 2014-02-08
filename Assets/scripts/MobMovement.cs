using UnityEngine;
using System.Collections;

public class MobMovement : MonoBehaviour
{
    public float speed;
    
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, speed * Time.deltaTime);
    }
}
