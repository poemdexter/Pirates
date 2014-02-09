using UnityEngine;
using System.Collections;

public class MobMovement : MonoBehaviour
{
    public float speed;
    GameController gc;
    
    void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
    void Update()
    {
        if (gc.playing)
            transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, speed * Time.deltaTime);
    }
}
