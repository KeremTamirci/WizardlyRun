using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaCounter : MonoBehaviour
{
    public Text txt;

    void Start(){
        txt = GetComponent<Text>();
    }
    public void ManaDisplay(int mana){
        txt.text = mana.ToString();

    }
}
