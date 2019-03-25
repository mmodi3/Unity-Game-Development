using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    float speed = 2.0f;
    Vector3 position;
    Transform trans;
    
    void Start() {
        position = transform.position;
        trans = transform;
    }
    
    void Update() {
    
        if (Input.GetKey(KeyCode.D) && trans.position == position)
        {
            position += Vector3.right;
        }
        else if (Input.GetKey(KeyCode.A) && trans.position == position)
        {
            position += Vector3.left;
        }
        else if (Input.GetKey(KeyCode.W) && trans.position == position)
        {
            position += Vector3.up;
        }
        else if (Input.GetKey(KeyCode.S) && trans.position == position)
        {
            position += Vector3.down;
        }
    
        position = Vector3.MoveTowards(transform.position, position, Time.deltaTime * speed);
    }  
}
