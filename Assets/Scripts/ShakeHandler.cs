/*
 * zak naydass
 * 10/28/2022
 * shakes the camera when the EventShake is called
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeHandler : MonoBehaviour
{
    public float Magnitude;
    public float duration;
    public CameraController cam;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void EventShake()
    {
        CameraController.StartShake(duration, Magnitude);
    }
}
