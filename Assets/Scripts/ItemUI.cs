using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour {

    public GameObject itemPrefab;

    private GvrLaserPointer laserPointer;

    private bool isSelected;
    private float lerpValue;
    private Vector3 selectedScale;
    private Color32 selectedLaserColor;
    private Color32 normalLaserColor;
    
    public void Start()
    {
        laserPointer = GameObject.Find("Player").transform.Find("GvrControllerPointer/Laser").GetComponent<GvrLaserPointer>();

        isSelected = false;
        lerpValue = 0;
        selectedScale = new Vector3(1.2f, 1.2f, 1.2f);
        selectedLaserColor = new Color32(0, 255, 0, 128);
        normalLaserColor = new Color32(255, 255, 255, 128);
    }

    public void Update()
    {
        if (isSelected)
        {
            if (lerpValue < 1) {
                lerpValue += Time.deltaTime * 5;
                transform.localScale = Vector3.Lerp(Vector3.one, selectedScale, lerpValue);
            }
        }
        else
        {
            if (lerpValue > 0)
            {
                lerpValue -= Time.deltaTime * 5;
                transform.localScale = Vector3.Lerp(Vector3.one, selectedScale, lerpValue);
            }
        }
    }

    public void PointerEnter()
    {
        isSelected = true;
        lerpValue = 0;
        laserPointer.laserColor = selectedLaserColor;
    }

    public void PointerExit()
    {
        isSelected = false;
        lerpValue = 1;
        laserPointer.laserColor = normalLaserColor;
    }

    public void InstanciateItem()
    {
        Debug.LogError("InstanciateItem");
        Camera.main.GetComponent<ItemSpawner>().InstantiateItem(itemPrefab);
        GameObject.Find("ItemSelectionMenuCanvas").SetActive(false);
    }
}
