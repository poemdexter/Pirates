using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public GameObject skeleton;
    public Transform trash;
    public float spawnRate;
    float currentTime;
    Transform[] spawnpoints;
    public bool playing { get; private set; }
    bool fireOut = false;
    
    void Start()
    {
        spawnpoints = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++) {
            spawnpoints[i] = transform.GetChild(i);
        }
        
        playing = true;
    }
	
    void Update()
    {
        if (playing && (currentTime += Time.deltaTime) > spawnRate) {
            currentTime = 0;
            GameObject s = (GameObject)Instantiate(skeleton, spawnpoints[Random.Range(0, transform.childCount)].position, Quaternion.identity);
            s.transform.parent = trash;
        }
        
        if (!playing && fireOut)
            Application.LoadLevel("title");
    }
    
    public void GameOver()
    {
        playing = false;
        GameObject.FindGameObjectWithTag("Campfire").GetComponent<CampfireFlicker>().BurnOutStart();
    }
    
    public void FireIsOut()
    {
        fireOut = true;
    }
}
