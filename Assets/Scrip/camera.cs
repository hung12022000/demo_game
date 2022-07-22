using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    LayerMask cube;
    public float rotationspeed = 1;
    public Transform root,body;
    private Vector3 cameraOffset;
    float MouseX;
    public Transform Cam;
    public float cur = 0.3f;
    public float time = 0.3f;
    float Angles;
    public play Player;
    RaycastHit hit;

    // Start is called before the first frame update

    void Start()
    {
        Player = FindObjectOfType<play>();
        Cursor.lockState = CursorLockMode.Locked;
        cameraOffset = root.position;
    }
    void FixedUpdate()
    {
        ComeraControl();
        
    }

    void ComeraControl()
    {
        root.transform.LookAt(root, Vector3.up);
        MouseX += Input.GetAxis("Mouse X") * rotationspeed;
        root.rotation = Quaternion.Euler(0, MouseX, 0);
        if (Player.move != true)
        {
     
            return;
        }
        else
        {
            Angles = Mathf.SmoothDampAngle(body.eulerAngles.y, root.eulerAngles.y, ref cur, time);
            body.rotation = Quaternion.Euler(0, Angles, 0);
        }
        Angles = Mathf.SmoothDampAngle(body.eulerAngles.y, root.eulerAngles.y, ref cur, time);
        body.rotation = Quaternion.Euler(0, Angles, 0);
    }
}
