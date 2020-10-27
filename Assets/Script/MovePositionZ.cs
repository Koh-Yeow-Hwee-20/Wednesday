using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePositionZ : MonoBehaviour
{
    //declaration --> Initialisation
    float forwardSpeed = 8.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z > 18)
        {
            Destroy(gameObject);
        }
        else
        {
            //transform.Translate(Vector3.forward * Time.deltaTime * forwardSpeed);
        }

        transform.Rotate(new Vector3(0, 0, 2.5f));
    }
}
