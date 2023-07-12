using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelFinishedData", menuName = "ScriptableLevelFinishedManager", order = 1)]
public class LevelController : ScriptableObject
{
    // Start is called before the first frame update
    public bool LvlCompleted = false;
    public string MapName;

    public int totalPoint;
    public int actualPoint;

    public bool getStatus() {
        return LvlCompleted;
    }

    public void setStatus(bool Status)
    {
        this.LvlCompleted = Status;
    }

    public void setMapName(string Name)
    {
        this.MapName = Name;
    }

    public string getMapName()
    {
        return MapName;
    }

    public void setTotalPoint(int TotalPoint)
    {
        this.totalPoint = TotalPoint;
    }

    public int getTotalPoint()
    {
        return totalPoint;
    }

    public void setActualPoint(int ActualPoint)
    {
        this.actualPoint = ActualPoint;
    }

    public int getActualPoint()
    {
        return actualPoint;
    }

}
