using UnityEngine;
using System.Collections;

public class CampfireFlicker : MonoBehaviour
{
    public float fromLightIntensity;
    public float toLightIntensity;
    public float speed;
    // Update is called once per frame
    void Start()
    {
        iTween.ValueTo(gameObject, iTween.Hash("from", fromLightIntensity, "to", toLightIntensity, "speed", speed, "loopType", "pingPong", "onUpdate", "ChangeIntensity"));
    }
    
    void ChangeIntensity(float value)
    {
        light.intensity = value;
    }
}
