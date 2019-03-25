using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class playercontroller : MonoBehaviour
{
    public GameObject Kenny;
    public Tile Wall;
    public Tile Money;
    public float speed = 1.5f;
    float t;
    int wealth = 0;
    public Tilemap tilemap;

    Transform kennytransform;

    void Start() {

        kennytransform = Kenny.transform;
    }

    void Update(){
        Vector3Int originCell = tilemap.WorldToCell(kennytransform.position);
        Vector3Int destCell = new Vector3Int();
        Vector3 dest = new Vector3();

        if(Input.GetKeyDown("w")){
            StartCoroutine(proc_input('w', originCell, destCell, dest));
        }
        if(Input.GetKeyDown("a")){
            StartCoroutine(proc_input('a', originCell, destCell, dest));
        }
        if(Input.GetKeyDown("s")){
            StartCoroutine(proc_input('s', originCell, destCell, dest));
        }
        if(Input.GetKeyDown("d")){
            StartCoroutine(proc_input('d', originCell, destCell, dest));
        }
    }
    
     IEnumerator proc_input (char dir, Vector3Int origin_cell, Vector3Int destination_cell, Vector3 destination){
        if (dir == 'w'){
            destination_cell = origin_cell +new Vector3Int(0,1,0);
            destination = tilemap.GetCellCenterWorld(destination_cell);
        }
        else if (dir == 'a'){
            destination_cell = origin_cell +new Vector3Int(-1,0,0);
            destination = tilemap.GetCellCenterWorld(destination_cell);
        }
        else if (dir == 's'){
            destination_cell = origin_cell +new Vector3Int(0,-1,0);
            destination = tilemap.GetCellCenterWorld(destination_cell);
        }
        else if (dir == 'd'){
            destination_cell = origin_cell +new Vector3Int(1,0,0);
            destination = tilemap.GetCellCenterWorld(destination_cell);
        }
        t = Time.deltaTime*speed;
        int count = 100000;
        while(Vector3.Distance(kennytransform.position, destination)>0.01f){
            kennytransform.position = Vector3.MoveTowards(kennytransform.position, destination, t);
            count-=1;
            if (count %100 == 0){
                yield return new WaitForSeconds(.00000000000000001f);
            }
            Debug.Log(Vector3.Distance(kennytransform.position, destination));
            Debug.Log(count);

        }
        // Debug.Log(Vector3.Distance(kennytransform.position, destination));
        // Debug.Log(t);
    }

}


    












