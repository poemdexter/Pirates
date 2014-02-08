using UnityEngine;
using System.Collections;

public class CameraFollowPlayer : MonoBehaviour
{
    public float smooth = 1.5f;         // The relative speed at which the camera will catch up.
    private PlayerMovement player;      // Reference to the player's PlayerMovement script.
    private Vector3 relCameraPos;       // The relative position of the camera from the player.
    private float relCameraPosMag;      // The distance of the camera from the player.
    private Vector3 newPos;             // The position the camera is trying to reach.
    
    void Awake()
    {
        // Setting up the reference.
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        
        // set camera position to player's position
        transform.position = new Vector3(player.gameObject.transform.position.x, player.gameObject.transform.position.y, transform.position.z);
        
        // Setting the relative position as the initial relative position of the camera in the scene.
        relCameraPos = transform.position - player.gameObject.transform.position;
        relCameraPosMag = relCameraPos.magnitude - 0.5f;
    }
    
    void Update()
    {
        // get player's pointing position so camera stays ahead of player if we're walking
        Vector3 playerPointing = player.GetPlayerPointingPosition();
        
        // The standard position of the camera is the relative position of the camera from the player.
        Vector3 standardPos = playerPointing + relCameraPos;
        
        // The abovePos is directly above the player at the same distance as the standard position.
        Vector3 abovePos = playerPointing + Vector3.up * relCameraPosMag;
        
        // An array of 5 points to check if the camera can see the player.
        Vector3[] checkPoints = new Vector3[5];
        
        // The first is the standard position of the camera.
        checkPoints[0] = standardPos;
        
        // The next three are 25%, 50% and 75% of the distance between the standard position and abovePos.
        checkPoints[1] = Vector3.Lerp(standardPos, abovePos, 0.25f);
        checkPoints[2] = Vector3.Lerp(standardPos, abovePos, 0.5f);
        checkPoints[3] = Vector3.Lerp(standardPos, abovePos, 0.75f);
        
        // The last is the abovePos.
        checkPoints[4] = abovePos;
        
        // Run through the check points...
        for (int i = 0; i < checkPoints.Length; i++) {
            // ... if the camera can see the player...
            if (ViewingPosCheck(playerPointing, checkPoints[i]))
                // ... break from the loop.
                break;
        }
        
        // Lerp the camera's position between it's current position and it's new position.
        transform.position = Vector3.Lerp(transform.position, newPos, smooth * Time.deltaTime);
    }
    
    
    bool ViewingPosCheck(Vector3 playerPointing, Vector3 checkPos)
    {
        RaycastHit hit;
        
        // If a raycast from the check position to the player hits something...
        if (Physics.Raycast(checkPos, playerPointing - checkPos, out hit, relCameraPosMag))
            // ... if it is not the player...
        if (hit.transform != player)
                // This position isn't appropriate.
            return false;
        
        // If we haven't hit anything or we've hit the player, this is an appropriate position.
        newPos = checkPos;
        return true;
    }
}