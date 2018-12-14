using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StageStatus
{
    Locked,Star0,Star1,Star2,Star3
}

[System.Serializable]
public class Save  {
    

    public List<StageStatus> StageScoreSave=new List<StageStatus>();
          
    	
}
