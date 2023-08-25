using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    
    [SerializeField]
    private GameObject _spherePrefab;
    public autoShoot aS;
    public Mana_Collection mc;
    public int current_mana;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Shoot()
    {
        current_mana = FindObjectOfType<Mana_Collection>().GetMana();
        if (current_mana > 0){
            Instantiate(_spherePrefab, transform.position + new Vector3(-0.05f, 1, 0.6f), Quaternion.identity);
            FindObjectOfType<Mana_Collection>().AddMana(false, false, true, 1);
        }
    }
    // Update is called once per frame
    void Update()
    {



    }
}