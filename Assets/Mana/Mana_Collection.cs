using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mana_Collection : MonoBehaviour
{
    public int _mana = 0;
    public ManaCounter mc;
    // private UIManager _uiManager;
    // Start is called before the first frame update
    void Start()
    {
        
        // _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        // if(_uiManager == null)
        // {
        //     Debug.LogError("The UI Manager is NULL.");
        // }
    }

    // Update is called once per frame
    void Update()
    {
        if (_mana < 0){
            AddMana (true, false, false, -_mana);
        }
    }

    public void AddMana(bool add, bool multiply, bool subtract, int x)
    {
        if (add) {
            _mana += x;
        }
        else if (multiply){
            _mana *= x;
        }
        else if (subtract) {
            _mana -= x;
        }
        FindObjectOfType<ManaCounter>().ManaDisplay(_mana);
        // _uiManager.UpdateManaDisplay(_mana);
    }

    public int GetMana(){
        return _mana;
    }


}


