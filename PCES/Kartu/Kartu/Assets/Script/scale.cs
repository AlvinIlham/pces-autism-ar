using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scale : MonoBehaviour
    
{
    private bool isScale;
    private float scaleSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isScale)
        {
            transform.localScale += Vector3.one * scaleSpeed * Time.deltaTime;
        }
    }

    public void ScaleCube(float speed)
    {
        isScale = true;
        scaleSpeed = speed;
    }
    public void Stop()
    {
        isScale = false;
    }
}
