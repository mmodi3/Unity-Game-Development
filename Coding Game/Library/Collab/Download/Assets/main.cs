using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class main : MonoBehaviour
{
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
            davetransform.position = pos;
            return 's';
        } else if (tilemap.GetTile<Tile>(originCell + new Vector3Int(0,-1,0)) == Wall){
            originCell += new Vector3Int(0,1,0);
            Vector3 pos = tilemap.GetCellCenterWorld(originCell);
            davetransform.position = pos;
            return 'n';
        } else {
            if (direction == 's'){
                originCell += new Vector3Int(0,-1,0);
                Vector3 pos = tilemap.GetCellCenterWorld(originCell);
                davetransform.position = pos;
            } else {
                originCell += new Vector3Int(0,1,0);
                Vector3 pos = tilemap.GetCellCenterWorld(originCell);
                davetransform.position = pos;
            }
            return direction;
        }
    }

    char edieMove(char direction){
        Vector3Int originCell = tilemap.WorldToCell(edietransform.position);
        if (tilemap.GetTile<Tile>(originCell + new Vector3Int(0,1,0)) == Wall){
            originCell += new Vector3Int(0,-1,0);
            Vector3 pos = tilemap.GetCellCenterWorld(originCell);
            edietransform.position = pos;
            return 's';
        } else if (tilemap.GetTile<Tile>(originCell + new Vector3Int(0,-1,0)) == Wall){
            originCell += new Vector3Int(0,1,0);
            Vector3 pos = tilemap.GetCellCenterWorld(originCell);
            edietransform.position = pos;
            return 'n';
        } else {
            if (direction == 's'){
                originCell += new Vector3Int(0,-1,0);
                Vector3 pos = tilemap.GetCellCenterWorld(originCell);
                edietransform.position = pos;
            } else {
                originCell += new Vector3Int(0,1,0);
                Vector3 pos = tilemap.GetCellCenterWorld(originCell);
                edietransform.position = pos;
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
                gabetransform.position = pos;
                return '2';
            }else{
                originCell += new Vector3Int(-1,-1,0);
                Vector3 pos = tilemap.GetCellCenterWorld(originCell);
                gabetransform.position = pos;
                return '1';
            }
        }
        if (direction == '2'){
            if (tilemap.GetTile<Tile>(originCell + new Vector3Int(-1,0,0)) == Wall){
                originCell += new Vector3Int(1,1,0);
                Vector3 pos = tilemap.GetCellCenterWorld(originCell);
                gabetransform.position = pos;
                return '3';
            }else{
                originCell += new Vector3Int(-1,1,0);
                Vector3 pos = tilemap.GetCellCenterWorld(originCell);
                gabetransform.position = pos;
                return '2';
            }
        }
        if (direction == '3'){
            if ((tilemap.GetTile<Tile>(originCell + new Vector3Int(-1,0,0)) == Wall) && (tilemap.GetTile<Tile>(originCell + new Vector3Int(0,1,0)) == Wall)) {
                originCell += new Vector3Int(1,-1,0);
                Vector3 pos = tilemap.GetCellCenterWorld(originCell);
                gabetransform.position = pos;
                return '4';
            }else{
                originCell += new Vector3Int(1,1,0);
                Vector3 pos = tilemap.GetCellCenterWorld(originCell);
                gabetransform.position = pos;
                return '3';
            }
        }
        else {
            if (tilemap.GetTile<Tile>(originCell + new Vector3Int(1,0,0)) == Wall){
                originCell += new Vector3Int(-1,-1,0);
                Vector3 pos = tilemap.GetCellCenterWorld(originCell);
                gabetransform.position = pos;
                return '1';
            }else{
                originCell += new Vector3Int(1,-1,0);
                Vector3 pos = tilemap.GetCellCenterWorld(originCell);
                gabetransform.position = pos;
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
        kennytransform.position = pos;
    }

    IEnumerator death(){
        yield return new WaitForSeconds(0.5f);
    }

    IEnumerator movementHub(string s){
        if (Instructions.readOnly == false){
            Instructions.readOnly = true;
            for (int i = 0; i < s.Length; i++){
                if (s[i] == 'S' || s[i] == 'N' || s[i] == 'E' || s[i] == 'W' || s[i] == 'P'){
                    davedirection = daveMove(davedirection);
                    gabedirection = gabeMove(gabedirection);
                    ediedirection = edieMove(ediedirection);
                    process(s[i]);
                    if (davetransform.position == kennytransform.position || gabetransform.position == kennytransform.position || edietransform.position == kennytransform.position){
                        yield return new WaitForSeconds(0.5f);
                        SceneManager.LoadScene("lose");
                    }
                    if(tilemap.GetTile<Tile>(tilemap.WorldToCell(kennytransform.position)) == Money){
                        wealth++;
                        tilemap.SetTile(tilemap.WorldToCell(kennytransform.position), null);
                    }
                    yield return new WaitForSeconds(0.5f);
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


    












