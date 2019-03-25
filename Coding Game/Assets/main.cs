using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class main : MonoBehaviour
{
    public float speed = 1.5f;
    public AudioSource audioSource;
    public GameObject Kenny;
    public GameObject GabE;
    public GameObject EdiE;
    public GameObject DavE;
    public InputField Instructions;
    public Tile Wall;
    public Tile Money;
    int wealth = 0;
    public Tilemap tilemap;
    InputField.SubmitEvent SubEve;

    Transform kennytransform;

    Transform davetransform;

    Transform edietransform;
    
    Transform gabetransform;

    Vector3 gabedestination;
    Vector3 ediedestination;
    Vector3 davedestination;
    Vector3 kennydestination;
    char davedirection = 'n';
    char gabedirection = '1';
    char ediedirection = 's';
    void Start() {
        SubEve = new InputField.SubmitEvent();
        SubEve.AddListener(delegate {StartCoroutine(movementHub((Instructions.text).ToUpper()));});
        Instructions.onEndEdit = SubEve;
        kennytransform = Kenny.transform;
        davetransform = DavE.transform;
        edietransform = EdiE.transform;
        gabetransform = GabE.transform;
    }

    char daveMove(char direction){
        Vector3Int originCell = tilemap.WorldToCell(davetransform.position);
        if (tilemap.GetTile<Tile>(originCell + new Vector3Int(0,1,0)) == Wall){
            originCell += new Vector3Int(0,-1,0);
            Vector3 pos = tilemap.GetCellCenterWorld(originCell);
            davedestination = pos;
            return 's';
        } else if (tilemap.GetTile<Tile>(originCell + new Vector3Int(0,-1,0)) == Wall){
            originCell += new Vector3Int(0,1,0);
            Vector3 pos = tilemap.GetCellCenterWorld(originCell);
            davedestination = pos;
            return 'n';
        } else {
            if (direction == 's'){
                originCell += new Vector3Int(0,-1,0);
                Vector3 pos = tilemap.GetCellCenterWorld(originCell);
                davedestination = pos;
            } else {
                originCell += new Vector3Int(0,1,0);
                Vector3 pos = tilemap.GetCellCenterWorld(originCell);
                davedestination = pos;
            }
            return direction;
        }
    }

    char edieMove(char direction){
        Vector3Int originCell = tilemap.WorldToCell(edietransform.position);
        if (tilemap.GetTile<Tile>(originCell + new Vector3Int(0,1,0)) == Wall){
            originCell += new Vector3Int(0,-1,0);
            Vector3 pos = tilemap.GetCellCenterWorld(originCell);
            ediedestination = pos;
            return 's';
        } else if (tilemap.GetTile<Tile>(originCell + new Vector3Int(0,-1,0)) == Wall){
            originCell += new Vector3Int(0,1,0);
            Vector3 pos = tilemap.GetCellCenterWorld(originCell);
            ediedestination = pos;
            return 'n';
        } else {
            if (direction == 's'){
                originCell += new Vector3Int(0,-1,0);
                Vector3 pos = tilemap.GetCellCenterWorld(originCell);
                ediedestination = pos;
            } else {
                originCell += new Vector3Int(0,1,0);
                Vector3 pos = tilemap.GetCellCenterWorld(originCell);
                ediedestination = pos;
            }
            return direction;
        }
    }

    char gabeMove(char direction){
        Vector3Int originCell = tilemap.WorldToCell(gabetransform.position);
        Debug.Log(direction);
        if (direction == '1'){
            if (tilemap.GetTile<Tile>(originCell + new Vector3Int(-1,-1,0)) == Wall){
                originCell += new Vector3Int(-1,1,0);
                Vector3 pos = tilemap.GetCellCenterWorld(originCell);
                gabedestination = pos;
                return '2';
            }else{
                originCell += new Vector3Int(-1,-1,0);
                Vector3 pos = tilemap.GetCellCenterWorld(originCell);
                gabedestination = pos;
                return '1';
            }
        }
        if (direction == '2'){
            if (tilemap.GetTile<Tile>(originCell + new Vector3Int(-1,0,0)) == Wall){
                originCell += new Vector3Int(1,1,0);
                Vector3 pos = tilemap.GetCellCenterWorld(originCell);
                gabedestination = pos;
                return '3';
            }else{
                originCell += new Vector3Int(-1,1,0);
                Vector3 pos = tilemap.GetCellCenterWorld(originCell);
                gabedestination = pos;
                return '2';
            }
        }
        if (direction == '3'){
            if ((tilemap.GetTile<Tile>(originCell + new Vector3Int(-1,0,0)) == Wall) && (tilemap.GetTile<Tile>(originCell + new Vector3Int(0,1,0)) == Wall)) {
                originCell += new Vector3Int(1,-1,0);
                Vector3 pos = tilemap.GetCellCenterWorld(originCell);
                gabedestination = pos;
                return '4';
            }else{
                originCell += new Vector3Int(1,1,0);
                Vector3 pos = tilemap.GetCellCenterWorld(originCell);
                gabedestination = pos;
                return '3';
            }
        }
        else {
            if (tilemap.GetTile<Tile>(originCell + new Vector3Int(1,0,0)) == Wall){
                originCell += new Vector3Int(-1,-1,0);
                Vector3 pos = tilemap.GetCellCenterWorld(originCell);
                gabedestination = pos;
                return '1';
            }else{
                originCell += new Vector3Int(1,-1,0);
                Vector3 pos = tilemap.GetCellCenterWorld(originCell);
                gabedestination = pos;
                return '4';
            }
        }
    }

    void process(char s){
        Vector3Int originCell = tilemap.WorldToCell(kennytransform.position);
            if (s == 'e' || s == 'E') {
                if (tilemap.GetTile<Tile>(originCell + new Vector3Int(1,0,0)) != Wall){
                   originCell += new Vector3Int(1,0,0);
                } else {
                    death();
                }
            }
            else if (s == 'w' || s == 'W') {
                if (tilemap.GetTile<Tile>(originCell + new Vector3Int(-1,0,0)) != Wall){
                   originCell += new Vector3Int(-1,0,0);
                } else {
                    death();
                }
            }
            else if (s == 'n' || s == 'N') {
                if (tilemap.GetTile<Tile>(originCell + new Vector3Int(0,1,0)) != Wall){
                   originCell += new Vector3Int(0,1,0);
                } else {
                    death();
                }
            }
            else if (s == 's' || s == 'S') {
                if (tilemap.GetTile<Tile>(originCell + new Vector3Int(0,-1,0)) != Wall){
                   originCell += new Vector3Int(0,-1,0);
                } else {
                    death();
                }
            }
        Vector3 pos = tilemap.GetCellCenterWorld(originCell);
        kennydestination = pos;
    }

    IEnumerator death(){
        yield return new WaitForSeconds(0.5f);
    }

    IEnumerator movementHub(string s){
        if (Instructions.readOnly == false){
            Instructions.readOnly = true;
            float t = Time.deltaTime*speed;
            int count = 100000;
            for (int i = 0; i < s.Length; i++){
                if (s[i] == 'S' || s[i] == 'N' || s[i] == 'E' || s[i] == 'W' || s[i] == 'P'){
                    audioSource.Play();
                    davedirection = daveMove(davedirection);
                    gabedirection = gabeMove(gabedirection);
                    ediedirection = edieMove(ediedirection);
                    process(s[i]);
                    while(Vector3.Distance(kennytransform.position, kennydestination)>0.0001f || Vector3.Distance(davetransform.position, davedestination)> 0.0001f || Vector3.Distance(edietransform.position, ediedestination)>0.0001f || Vector3.Distance(gabetransform.position, gabedestination)>0.0001f){
                        kennytransform.position = Vector3.MoveTowards(kennytransform.position, kennydestination, t);
                        davetransform.position = Vector3.MoveTowards(davetransform.position, davedestination, t);
                        edietransform.position = Vector3.MoveTowards(edietransform.position, ediedestination, t);
                        gabetransform.position = Vector3.MoveTowards(gabetransform.position, gabedestination, t);
                        count-=1;
                        Debug.Log("KENNY " + Vector3.Distance(kennytransform.position, kennydestination));
                        Debug.Log("GABE " + Vector3.Distance(gabetransform.position, gabedestination));
                        Debug.Log("EDIE " + Vector3.Distance(edietransform.position, ediedestination));
                        Debug.Log("DAVE " + Vector3.Distance(davetransform.position, davedestination));
                        if (count %5 == 0){
                            yield return new WaitForSeconds(.0000000001f);
                        }
                    }   
                    if (Vector3.Distance(davetransform.position,kennytransform.position) < .05f || Vector3.Distance(gabetransform.position, kennytransform.position) < .05f || Vector3.Distance(edietransform.position, kennytransform.position)<.05f){
                        yield return new WaitForSeconds(0.5f);
                        audioSource.Stop();
                        SceneManager.LoadScene("lose");
                    }
                    if(tilemap.GetTile<Tile>(tilemap.WorldToCell(kennytransform.position)) == Money){
                        wealth++;
                        tilemap.SetTile(tilemap.WorldToCell(kennytransform.position), null);
                    }
                    yield return new WaitForSeconds(0.5f);
                    audioSource.Stop();
                }
            }
            if (wealth == 3){
                yield return new WaitForSeconds(0.5f);
                SceneManager.LoadScene("win");
            }else{
                yield return new WaitForSeconds(0.5f);
                SceneManager.LoadScene("lose");
            }
        }
    }
    
}


    












