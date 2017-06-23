using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VrPopupMsg : MonoBehaviour {

    public GameObject root;
    public Text popupText;

	void Start () {
        root.SetActive(false);
	}

    public void ShowMsg(string msg)
    {
        CancelInvoke("HideMsg");
        popupText.text = msg;
        root.SetActive(true);
        Invoke("HideMsg", 3f);
        ShowInFrontOfPlayer();
    }

    public void HideMsg()
    {
        popupText.text = "";
        root.SetActive(false);
    }

    public void ShowInFrontOfPlayer()
    {
        transform.position = Camera.main.transform.position + (Camera.main.transform.forward * 1.5f);
        transform.eulerAngles = Camera.main.transform.eulerAngles;
    }
}
