using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCWButton : InterractableButton {

    public Axis rotateToAxis;

    private ItemMenu itemMenu;

    public override void Start()
    {
        base.Start();

        itemMenu = GetComponentInParent<ItemMenu>();
    }

    public void RotateClockwise()
    {
        Debug.LogError("RotateClockwise");
        itemMenu.RotateClockwise(rotateToAxis);
    }
}
