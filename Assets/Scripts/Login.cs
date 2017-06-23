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
    private RoomSelection roomListingPanel;

    [SerializeField]
    private GameObject roomGameObject;

    void Start() {
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
        iTween.MoveTo (gameObject, iTween.Hash ("position", transform.position + (Vector3.left * 1000f), "time", 0.3f, "oncomplete", "OnCompleteAnimation",
            "oncompletetarget", gameObject));
    }

    void OnCompleteAnimation() {
        roomListingPanel.ShowSelectionPanel ();
        gameObject.SetActive (false);
        roomGameObject.SetActive (false);
    }

}