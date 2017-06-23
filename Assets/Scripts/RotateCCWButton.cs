using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCCWButton : InterractableButton
{
    public Axis rotateToAxis;

    private ItemMenu itemMenu;

    public override void Start()
    {
        base.Start();

        itemMenu = GetComponentInParent<ItemMenu>();
    }

    public void RotateCounterClockwise()
    {
        Debug.LogError("RotateCounterClockwise");
        itemMenu.RotateCounterClockwise(rotateToAxis);
    }
}