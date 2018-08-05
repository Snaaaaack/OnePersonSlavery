using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Data {
    private static int stage;
    private static bool[] stagedata;

    public static int Stage {
        get { return stage; }
        set { stage = value; }
    }
    public static bool[] StageData {
        get { return stagedata; }
        set { stagedata = value; }
    }
}