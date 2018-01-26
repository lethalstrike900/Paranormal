using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookController : MonoBehaviour {

    Vector2 mouseLook;
    Vector2 smoothV;
    public float sensitivity = 5.0f;
    public float smoothing = 2f;
    private float rotationY = 0f;
    float max = 60.0f;
    float min = -45.0f;
    GameObject character;
    Vector3 v3Rotate = Vector3.zero;
   

    void Start () {
        character = this.transform.parent.gameObject;
        
    }
     
     void Update () {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        mouseLook += smoothV;

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);

        LockRotateY();
     }

    void LockRotateY()
    {
        rotationY += Input.GetAxis("Mouse Y") * sensitivity;
        rotationY = Mathf.Clamp(rotationY, min, max);

        transform.localEulerAngles = new Vector3(-rotationY, 0, 0);

    }
	 
}
