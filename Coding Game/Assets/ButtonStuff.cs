using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonStuff : MonoBehaviour
{
    public InputField mainInputField;
    public Button Down;
    public Button Up;
    public Button Right;
    public Button Left;

    public void displayCons(string str){
        if (mainInputField.readOnly == false){
            mainInputField.text += str;
        }
    }
}
