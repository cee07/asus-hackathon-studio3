using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCWButton : InterractableButton {

    public Axis rotateToAxis;

    public void RotateClockwise()
    {
        Debug.LogError("RotateClockwise");
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
