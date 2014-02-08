using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour
{
    float shake;
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;
    
    public void Shake()
    {
        shake = shakeAmount;
    }
    
    void Update()
    {
        if (shake > 0) {
            Vector3 pos = Random.insideUnitSphere * shake;
            transform.position += new Vector3(pos.x, pos.y, 0); 
            shake -= Time.deltaTime * decreaseFactor;
        } else {
            shake = 0;  
        }
    }
}