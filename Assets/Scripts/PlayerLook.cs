using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    private float xRotation = 0f;
    //private float yRotation = 0f;

    public float xSensitivity = 2f;
    public float ySensitivity = 2f;

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        //calculate camera rotation for looking up and down
        xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -30f, 30f);

        //apply this to our camera transform.
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        //rotate player to look left and right
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
        










        //transform.Rotation.y = Mathf.Clamp(transform.Rotation.y, -30f, 30f);

        /*yRotation = cam.transform.eulerAngles.y;
        if (cam.transform.eulerAngles.y < -50f)
        {
            yRotation += 0f;
        }
        else if (cam.transform.eulerAngles.y > 50f)
        {
            yRotation += 0f;
        }
        else
        {
            yRotation = cam.transform.eulerAngles.y;
        }
        transform.eulerAngles = new Vector3(0, yRotation, transform.eulerAngles.z);*/
    }
}
