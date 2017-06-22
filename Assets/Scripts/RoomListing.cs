using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomListing : MonoBehaviour {

    [SerializeField]
    private List<Room> rooms = new List<Room> ();

	// Use this for initialization
	void Start () {
        Init ();
        AddListeners ();
	}

    void OnDestroy() {
        RemoveListeners ();
    }

    void Init() {
        for (int index = 0; index < rooms.Count; index++) {
            Room room = rooms[index];
            room.SetRoomText ("Room " + (index + 1).ToString ());
        }
    }

    void OnEnable() {
        foreach (Room room in rooms) {
            iTween.ScaleFrom (room.gameObject, iTween.Hash ("time", 0.5f, "easetype", iTween.EaseType.spring, "scale", Vector3.zero));
        }
    }

    void AddListeners() {
        foreach (Room room in rooms)
            room.OnRoomClicked += OnRoomClicked;
    }

    void RemoveListeners() {
        foreach (Room room in rooms)
            room.OnRoomClicked -= OnRoomClicked;
    }

    void OnRoomClicked() {
        gameObject.SetActive (false);
    }
}
