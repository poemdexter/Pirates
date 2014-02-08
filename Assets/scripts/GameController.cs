using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public GameObject skeleton;
    public Transform trash;
    public float spawnRate;
    float currentTime;
    Transform[] spawnpoints;
    bool playing;
    
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
    }
    
    public void GameOver()
    {
        playing = false;
        currentTime = 0;
        foreach (Transform child in trash) {
            Destroy(child.gameObject);
        }
    }
}
