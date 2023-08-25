using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
   [SerializeField]
   private Text _manaText;
   public void UpdateManaDisplay(int mana)
   {
       _manaText.text =  mana.ToString();
   }
}
