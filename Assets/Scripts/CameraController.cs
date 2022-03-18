using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    private Vector3 point;
    // Start is called before the first frame update
    void Start()
    {
        point = target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        
        transform.RotateAround (point,new Vector3(0.0f,1.0f,0.0f),20 * Time.deltaTime * 8.0f * horizontalInput);
        //transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * 20);
    }
}
