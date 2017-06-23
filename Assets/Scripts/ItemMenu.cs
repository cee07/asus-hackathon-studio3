using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMenu : MonoBehaviour {

	void Start()
    {
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
    }

    public void Remove()
    {
        Debug.LogError("Remove");
    }

    
}
