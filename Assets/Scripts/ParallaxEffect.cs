using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{

    public float parallaxEffect;

    private Transform cameraMain;
    private Vector3 lastPosCamera;
    // Start is called before the first frame update
    void Start()
    {
        cameraMain = Camera.main.transform;
        lastPosCamera = cameraMain.position;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        Vector3 backgroundMovement = cameraMain.position - lastPosCamera;
        transform.position += new Vector3(backgroundMovement.x * parallaxEffect, backgroundMovement.y, 0);
        lastPosCamera = cameraMain.position;
    }
}
