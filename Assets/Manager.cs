using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public System.Random ran = new System.Random();
    public GameObject startPanel;
    public GameObject inGamePanel;
    public GameObject deathPanel;
    public GameObject endPanel;
    public GameObject soundonpic;
    public GameObject soundoffpic;
    public Movement mv;
    public autoShoott aus;
    public TouchDragControls1 tdc1;
    public AdsManagerScript ads;
    public bool hasStarted;
    public int levelsPlayed;
    public int levels;
    public int lastindex;
    public bool levellarbitti = false;
    public int loadindex;
    public DataManager data;
    public bool gameJustStarted = true;
    public bool soundon = true;
    // Start is called before the first frame update
    void Start()
    {

        levels = 27;
        levelsPlayed = 0;
        deathPanel.SetActive(false);
        hasStarted = false;
        inGamePanel.SetActive(false);
        startPanel.SetActive(true);
        endPanel.SetActive(false);
        DisablePlayer();
        LoadManager();
        /*if (levelsPlayed < levels)
        {
            if (SceneManager.GetActiveScene().buildIndex != levelsPlayed)
            {
                SceneManager.LoadScene(levelsPlayed);
            }
        }
        else
        {
            SceneManager.LoadScene(ran.Next(0, levels - 1));
        }*/
        
        if (SceneManager.GetActiveScene().buildIndex != lastindex)
        {
            SceneManager.LoadScene(lastindex);
        }
        Debug.Log("şu bölümü oynuyorsun : " + lastindex);
        


        if(UnityEngine.AudioListener.volume == 0)
        {
            NoSound();
        }
        else if (UnityEngine.AudioListener.volume == 1)
        {
            YesSound();
        }



    }
    public void DisablePlayer()
    {
        mv.enabled = false;
        aus.enabled = false;
        tdc1.enabled = false;
    }
    public void EnablePlayer()
    {
        mv.enabled = true;
        aus.enabled = true;
        tdc1.enabled = true;
        if (deathPanel != null)
        {
            deathPanel.SetActive(false);
        }

    }

    public void EnableWithoutDeathPanel()
    {
        mv.enabled = true;
        aus.enabled = true;
        tdc1.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void StartFunction()
    {
        if (SceneManager.GetActiveScene().buildIndex >= (levels - 1))
        {
            levellarbitti = true;
        }
        Debug.Log("Bastı");
        hasStarted = true;
        tdc1.started = true;
        inGamePanel.SetActive(true);
        startPanel.SetActive(false);
        EnablePlayer();
    }
    public void DeathFunction()
    {
        Debug.Log("ikinci kere öldü inş");
        inGamePanel.SetActive(false);
        startPanel.SetActive(false);
        deathPanel.SetActive(true);

    }
    public void ReloadFunc()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextLevel()
    {
        if (!levellarbitti)
        {
            lastindex = SceneManager.GetActiveScene().buildIndex + 1;
            SaveManager();
            SceneManager.LoadScene(lastindex);

        }
        else
        {
            lastindex = ran.Next(0, levels - 1);
            SaveManager();
            SceneManager.LoadScene(lastindex);
        }

        levelsPlayed = levelsPlayed + 1;
        if ((SceneManager.GetActiveScene().buildIndex % 2) == 1)
        {
            FindObjectOfType<AdsManagerScript>().PlayAd();
        }

    }
    public void LevelEnded()
    {
        deathPanel.SetActive(false);
        inGamePanel.SetActive(false);
        startPanel.SetActive(false);
        endPanel.SetActive(true);
        DisablePlayer();
        SaveManager();
    }

    public void SaveManager()
    {
        SystemSaver.SaveManager(this);
        Debug.Log("oynanan bölüm sayısı" + levelsPlayed);
    }

    public void LoadManager()
    {
        DataManager data = SystemSaver.LoadManager();
        levellarbitti = data.levellarbitti;
        levelsPlayed = data.levelsPlayed;
        lastindex = data.lastindex;
    }

    public void NoSound()
    {
        
        UnityEngine.AudioListener.volume = 0;
        soundon = false;
        soundonpic.SetActive(false);
        soundoffpic.SetActive(true);

    }

    public void YesSound()
    {
        UnityEngine.AudioListener.volume = 1;
        soundon = true;
        soundonpic.SetActive(true);
        soundoffpic.SetActive(false);
    }

    public void SoundButton()
    {
        
        if (soundon)
        {
            
            NoSound();
        }
        else if (!soundon)
        {
            YesSound();
        }
    }
}