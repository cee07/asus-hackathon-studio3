using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class RoomGvrController : MonoBehaviour {

    private ItemSelection itemSelection;
    private GvrLaserPointer laserPointer;

    private void Awake()
    {
        itemSelection = GameObject.Find("ItemSelectionMenuCanvas").GetComponent<ItemSelection>();
    }

    private void Start()
    {
        laserPointer = GameObject.Find("Player").transform.Find("GvrControllerPointer/Laser").GetComponent<GvrLaserPointer>();
    }

    void Update () {
        if (GvrController.AppButtonDown)
        {
            if (itemSelection.gameObject.activeSelf)
            {
                itemSelection.gameObject.SetActive(false);
            }
            else
            {
                itemSelection.gameObject.SetActive(true);
                itemSelection.ShowInFrontOfPlayer();
            }
        }

        if (GvrController.State == GvrConnectionState.Connected)
        {
            laserPointer.maxLaserDistance = 2.5f;
        }
    }
}
