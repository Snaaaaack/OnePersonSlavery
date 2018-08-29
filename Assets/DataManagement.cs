using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Data {
    private static int stage;
    private static int destX;
    private static int destY;
    
    private static bool[] stagedata = new bool[6];

    public static int Stage { get { return stage; } set { stage = value; } }
    public static bool[] StageData { get { return stagedata; } set { stagedata = value; } }
    public static int DestArea { get { return destX; } set { destX = value; } }
    public static int DestTile { get { return destY; } set { destY = value; } }
}