using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public float upAndDown = 1f;
    private float step = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (upAndDown > 0.8f)
        {
            step = -0.01f;
        }
        else if(upAndDown < -0.8f)
        {
            step = 0.01f;
        }
        upAndDown += step;
        transform.Rotate(Vector3.up, Time.deltaTime * 50f);
        transform.Translate(Vector3.up * upAndDown * 0.01f);
    }
}
