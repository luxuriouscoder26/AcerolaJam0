using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{ public Transform[] cameraPositions; 

    private int currentPositionIndex = 0; 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MoveCameraToNextPosition();
            Debug.Log("Player Detected");
        }
    }

    private void MoveCameraToNextPosition()
    {
      
        Camera.main.transform.position = cameraPositions[currentPositionIndex].position;
        Camera.main.transform.rotation = cameraPositions[currentPositionIndex].rotation;
        currentPositionIndex++;
        if (currentPositionIndex >= cameraPositions.Length)
        {
            currentPositionIndex = 0;
        }
    }
}
