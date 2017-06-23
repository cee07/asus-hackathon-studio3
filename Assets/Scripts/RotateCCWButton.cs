using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCCWButton : InterractableButton
{

    public Axis rotateToAxis;

    public void RotateCounterClockwise()
    {
        Debug.LogError("RotateCounterClockwise");
        if (rotateToAxis == Axis.XAxis)
        {

        }
        else if (rotateToAxis == Axis.YAxis)
        {

        }
        else if (rotateToAxis == Axis.ZAxis)
        {

        }
    }
}