using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class soundshit : MonoBehaviour
{
    public bool soundon = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void NoSound()
    {
        UnityEngine.AudioListener.volume = 0;
        soundon = false;
    }

    void YesSound()
    {
        UnityEngine.AudioListener.volume = 1;
        soundon = true;
    }

    void SoundButton()
    {
        if (soundon)
        {
            NoSound();
        }
        if (!soundon)
        {
            YesSound();
        }
    }
}
