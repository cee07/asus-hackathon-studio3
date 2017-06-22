using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room : MonoBehaviour {

    public System.Action<Sprite> OnRoomClicked;
    public System.Action<int> OnToggle;

    [SerializeField]
    private GameObject panel;

    [SerializeField]
    private Text roomText;

    [SerializeField]
    private Image roomImage;

    private Toggle toggleInstance;

    private int index;

	void Start () {
        toggleInstance = GetComponent<Toggle> ();
        AddListeners ();
	}

    void OnDestroy() {
        RemoveListeners ();
    }

    void AddListeners() {
        toggleInstance.onValueChanged.AddListener (OnClickRoom);
    }

    void RemoveListeners() {
        toggleInstance.onValueChanged.RemoveListener (OnClickRoom);
    }

    void OnClickRoom(bool toggled) {
        if (toggled) {
            if (OnToggle != null)
                OnToggle (index);
        }
        if (OnRoomClicked != null)
            OnRoomClicked (roomImage.sprite);
    }

    public void SetRoomText(int index) {
        this.index = index - 1;
        roomText.text = "Room " + index.ToString ();
    }

    public void SetImage(Sprite sprite) {
        roomImage.sprite = sprite;
    }

    public void Show() {
        panel.SetActive (true);
    }

    public void Hide() {
        panel.SetActive (false);
    }

}
