using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("m^s-1")] public float xSpeed = 5f;
    [Tooltip("m^s-1")] public float ySpeed = 5f;

    public float xRange = 8f;
    public float yRange = 4f;
    public float pitchFactor = -2f;
    public float yawFactor = -2f;

    public float controlPitchFactor = -20f;

    float xThrow = 0f;
    float yThrow = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Translation();
        Rotation();
    }

    void Rotation()
    {
        float pitch = transform.localPosition.y * pitchFactor + yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * -yawFactor - xThrow * controlPitchFactor; // transform.localPosition.x * -pitchFactor;
        float roll = xThrow * controlPitchFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void Translation() {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float yOffset = yThrow * ySpeed * Time.deltaTime;
        float newX = Mathf.Clamp(transform.localPosition.x + xOffset, -xRange, xRange);
        float newY = Mathf.Clamp(transform.localPosition.y + yOffset, -yRange, yRange);
        transform.localPosition = new Vector3(newX, newY, transform.localPosition.z);

        // transform.eulerAngles = new Vector3(
        //     transform.eulerAngles.x,
        //     transform.eulerAngles.y,
        //     -xThrow * 30
        // );
    }
}
