using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    Transform prev;
    // Start is called before the first frame update
    void Start()
    {
        prev = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (prev.position.x < transform.position.x){
            transform.eulerAngles = new Vector3(0, 180, 0);
        } else if (prev.position.x > transform.position.x){
            transform.eulerAngles = new Vector3(0,0,0);
        }
        prev = transform;
    }
}
