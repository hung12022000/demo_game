using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DichuyenBong : MonoBehaviour
{
    // Start is called before the first frame update
    public float max;
    public float min;
    public float current;
    public Transform ball;
    public float a;
    private void Awake()
    {
        current = Mathf.Lerp(ball.position.x, max, Time.deltaTime * a);
        transform.position = new Vector3(current, transform.position.y, transform.position.z);
    }
    // Update is called once per frame
    void Update()
    {
        current = min;
     
        if(current == max-1)
        {

            current = Mathf.Lerp(ball.position.x, min, Time.deltaTime * a);

        }

        if (current == min+1)
        {
            current = Mathf.Lerp(ball.position.x, max, Time.deltaTime * a);
           
        }
        transform.position = new Vector3(current, transform.position.y, transform.position.z);
    }
}
