using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pg_ship : MonoBehaviour
{
    Rigidbody rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidBody.freezeRotation = true;
        if (Input.GetKey(KeyCode.Space)) {
            rigidBody.AddRelativeForce(new Vector3(0, 20, 0));
        }

        if (Input.GetKey(KeyCode.D)) {
            transform.Rotate(new Vector3(0, 0, -5));
        } else if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(new Vector3(0, 0, 5));
        } else {
            if ((transform.eulerAngles.z < 5) || (transform.eulerAngles.z > 355) ) {
                print(transform.eulerAngles.z);
                transform.Rotate(0,0,0);
            } else {
                print("fix");
                if (transform.eulerAngles.z > 0 && transform.eulerAngles.z <= 180 ) {
                    transform.Rotate(new Vector3(0, 0, -1));
                } else {
                    transform.Rotate(new Vector3(0, 0, 1));
                }
            }
        }
    }
}
