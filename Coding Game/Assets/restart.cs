using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour
{
    public void restartB(){
        SceneManager.LoadScene("computergame");
    }
}
