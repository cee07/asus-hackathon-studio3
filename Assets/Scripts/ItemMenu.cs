using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMenu : MonoBehaviour {

    private Item mainObject;

	void Start()
    {
        mainObject = GetComponentInParent<Item>();

        gameObject.SetActive(false);
    }

    public void OnItemClicked()
    {
        if (gameObject.activeSelf)
            HideMenu();
        else
            ShowMenu();
    }

    public void ShowMenu()
    {
        gameObject.SetActive(true);
    }

    public void HideMenu()
    {
        gameObject.SetActive(false);
    }

    public void Move()
    {
        Debug.LogError("Move");
        Camera.main.GetComponent<ItemSpawner>().SetItem(mainObject);
    }

    public void Remove()
    {
        Debug.LogError("Remove");
        Destroy(mainObject.gameObject);
    }

    public void RotateClockwise(Axis axis)
    {
        if (axis == Axis.XAxis)
        {
            
        }
        else if (axis == Axis.YAxis)
        {
            int tIndex = mainObject.turnIndex;
            mainObject.GetComponent<Animator>().SetInteger("TurnIndex", tIndex);
            mainObject.GetComponent<Animator>().SetTrigger("TurnClockwise");
            tIndex++;
            if (tIndex == 4)
                tIndex = 0;
            mainObject.GetComponent<Item>().turnIndex = tIndex;
        }
        else if (axis == Axis.ZAxis)
        {
            mainObject.transform.eulerAngles = new Vector3(mainObject.transform.eulerAngles.x, mainObject.transform.eulerAngles.y, mainObject.transform.eulerAngles.z - 90);
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z + 270);
        }
    }

    public void RotateCounterClockwise(Axis axis)
    {
        if (axis == Axis.XAxis)
        {
            
        }
        else if (axis == Axis.YAxis)
        {
            int tIndex = mainObject.turnIndex;
            mainObject.GetComponent<Animator>().SetInteger("TurnIndex", tIndex);
            mainObject.GetComponent<Animator>().SetTrigger("TurnCounterClockwise");
            tIndex--;
            if (tIndex == -1)
                tIndex = 3;
            mainObject.turnIndex = tIndex;
        }
        else if (axis == Axis.ZAxis)
        {
            mainObject.transform.eulerAngles = new Vector3(mainObject.transform.eulerAngles.x, mainObject.transform.eulerAngles.y, mainObject.transform.eulerAngles.z + 90);
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z - 270);
        }
    }
}
