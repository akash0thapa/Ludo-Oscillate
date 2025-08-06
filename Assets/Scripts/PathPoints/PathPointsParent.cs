using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPointsParent : PathPoints
{
    public PathPoints[] commonPathPoints;
    public PathPoints[] redPathPoints;
    public PathPoints[] bluePathPoints;
    public PathPoints[] yellowPathPoints;
    public PathPoints[] greenPathPoints;
    public PathPoints[] safePathPoints;
    public float[] scales;
    public float[] positionDifference;
}
