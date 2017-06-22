using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour {

    [SerializeField]
    private InputField username;

    [SerializeField]
    private InputField password;

    [SerializeField]
    private Button loginButton;

    [SerializeField]
    private GameObject roomListingPanel;

	void Start () {
        AddListeners ();
	}

    void OnDestroy() {
        RemoveListeners ();   
    }

    void AddListeners() {
        loginButton.onClick.AddListener (OnClickLogin);
    }

    void RemoveListeners() {
        loginButton.onClick.RemoveListener (OnClickLogin);
    }

    void OnClickLogin() {
        if (string.IsNullOrEmpty (username.text))
            return;
        if (string.IsNullOrEmpty (password.text))
            return;
        roomListingPanel.SetActive (true);
        gameObject.SetActive (false);
    }


    
}
