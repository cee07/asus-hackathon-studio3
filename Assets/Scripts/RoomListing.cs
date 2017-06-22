using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoomListing : MonoBehaviour {

    private const string ROOM_TEXTURES_PATH = "Textures/Rooms";

    [SerializeField]
    private Transform roomPanel;

    private List<Room> rooms = new List<Room> ();
    private List<Sprite> roomSprites = new List<Sprite> ();

    void Start() {
        Init ();
        AddListeners ();
    }

    void OnDestroy() {
        RemoveListeners ();
    }

    void Init() {
        Sprite[] roomSpritesArray = (Sprite[]) Resources.LoadAll<Sprite>(ROOM_TEXTURES_PATH);
        roomSprites = roomSpritesArray.ToList ();
        rooms = roomPanel.GetComponentsInChildren<Room> ().ToList();
        for (int index = 0; index < rooms.Count; index++) {
            Room room = rooms[index];
            room.SetRoomText ("Room " + (index + 1).ToString ());
            room.SetImage (roomSprites[index]);
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
        iTween.MoveTo (gameObject, iTween.Hash ("position", transform.position + (Vector3.left * 1000f), "time", 0.3f, "oncomplete", "OnCompleteAnimation",
           "oncompletetarget", gameObject));
    }

    void OnCompleteAnimation() {
        gameObject.SetActive (false);
    }
}
