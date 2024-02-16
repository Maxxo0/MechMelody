using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private Transform cameraTransform;
    private Vector3 previousCamPos;
    public float velo;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;
        previousCamPos = cameraTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float deltaX = (cameraTransform.position.x - previousCamPos.x) * velo;
        transform.Translate(new Vector3(deltaX, 0, 0));
        previousCamPos = cameraTransform.position;
    }
}
