using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class DataManager
{
    public bool levellarbitti;
    public int levelsPlayed;
    public int lastindex;

    public DataManager (Manager manager)
    {
        levellarbitti = manager.levellarbitti; 
        levelsPlayed = manager.levelsPlayed;
        lastindex = manager.lastindex;

    }
}
