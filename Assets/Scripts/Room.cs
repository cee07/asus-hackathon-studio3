using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room : MonoBehaviour {

    public System.Action OnRoomClicked;

    [SerializeField]
    private Text roomText;

    private Button buttonInstance;

	void Start () {
        buttonInstance = GetComponent<Button> ();
        AddListeners ();
	}

    void OnDestroy() {
        RemoveListeners ();
    }

    void AddListeners() {
        buttonInstance.onClick.AddListener (OnClickRoom);
    }

    void RemoveListeners() {
        buttonInstance.onClick.RemoveListener (OnClickRoom);
    }

    void OnClickRoom() {
        if (OnRoomClicked != null)
            OnRoomClicked ();
    }

    public void SetRoomText(string text) {
        roomText.text = text;
    }


}
