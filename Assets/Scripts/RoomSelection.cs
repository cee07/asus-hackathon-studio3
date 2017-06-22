using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class RoomSelection : MonoBehaviour {

    private const string ROOM_TEXTURES_PATH = "Textures/Rooms";

    [SerializeField]
    private Dropdown roomDropdown;

    [SerializeField]
    private Transform roomsPanel;

    [SerializeField]
    private List<Room> rooms = new List<Room> ();

    [SerializeField]
    private List<Block> blocks = new List<Block> ();

    [SerializeField]
    private Button view;

    [SerializeField]
    private RoomDetails roomDetails;

    [SerializeField]
    private GameObject roomGameObject;

     [SerializeField]
    private GameObject cityGO;

    [SerializeField]
    private GameObject selectionPanel;
    
    private Block currentBlock;

    private Sprite currentSprite;

    void Start() {
        InitializeRooms ();
        AddListeners ();
    }

    void OnDestroy() {
        RemoveListeners ();
    }

    void AddListeners() {
        roomDropdown.onValueChanged.AddListener (OnDropdownValueChanged);
        view.onClick.AddListener (OnClickView);
    }

    void RemoveListeners() {
        roomDropdown.onValueChanged.RemoveListener (OnDropdownValueChanged);
        for (int index = 0; index < rooms.Count; index++) {
            Room room = rooms[index];
            room.OnToggle -= OnToggledRoom;
            room.OnRoomClicked -= OnRoomToogled;
        }
        view.onClick.RemoveListener (OnClickView);
    }

    void InitializeRooms() {
       // Room[] roomsArray = roomsPanel.GetComponentsInChildren<Room> ();
       // rooms = roomsArray.ToList ();

        Sprite[] roomSpritesArray = (Sprite[])Resources.LoadAll<Sprite> (ROOM_TEXTURES_PATH);

        for (int index = 0; index < rooms.Count; index++) {
            Room room = rooms[index];
            room.OnToggle += OnToggledRoom;
            room.OnRoomClicked += OnRoomToogled;
            room.SetRoomText (index + 1);
            room.SetImage (roomSpritesArray[index]);
        }

        OnDropdownValueChanged (0);
    }

    void OnRoomToogled(Sprite sprite) {
        currentSprite = sprite;
    }

    void OnClickView() {
        roomDetails.ShowDetails (currentSprite);
        roomGameObject.SetActive (true);
        cityGO.SetActive (false);
        selectionPanel.SetActive (false);
    }

    void OnToggledRoom(int index) {
        if (currentBlock != null)
            currentBlock.Hide ();
        int indexx = index % 2;
        GameObject tile = currentBlock.GetObjectByIndex (indexx);
        tile.SetActive (true);
    }

    void OnDropdownValueChanged(int index) {
        int calculatedIndex = 0;

        DisableBlocks ();
        DisableRooms ();

        switch (index) {
            case 0:
                calculatedIndex = 0;
                break;
            case 1:
                calculatedIndex = 2;
                break;
            case 2:
                calculatedIndex = 4;
                break;
            case 3:
                calculatedIndex = 6;
                break;
            case 4:
                calculatedIndex = 8;
                break;
            case 5:
                calculatedIndex = 10;
                break;
        }

      
        currentBlock = blocks[index];
        currentBlock.gameObject.SetActive (true);
        AnimateRooms (calculatedIndex);
    }

    void DisableBlocks() {
        foreach (Block block in blocks)
            block.gameObject.SetActive (false);
    }

    void DisableRooms() {
        foreach (Room room in rooms)
            room.Hide ();
    }

    void AnimateRooms(int index) {
        Room first = rooms[index];
        Room second = rooms[index + 1];
        first.Show ();
        second.Show ();
        iTween.ScaleFrom (rooms[index].gameObject, iTween.Hash ("time", 0.75f, "easetype", iTween.EaseType.spring, "scale", Vector3.zero));
        iTween.ScaleFrom (rooms[index + 1].gameObject, iTween.Hash ("time", 0.75f, "easetype", iTween.EaseType.spring, "scale", Vector3.zero));
    }

    public void ShowSelectionPanel() {
        selectionPanel.SetActive (true);
    }
}