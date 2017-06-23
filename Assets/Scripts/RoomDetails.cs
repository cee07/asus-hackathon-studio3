using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VR;

public class RoomDetails : MonoBehaviour {

    [SerializeField]
    private Image roomImage;

    [SerializeField]
    private Button viewVRButton;

    [SerializeField]
    private Button bookButton;

    [SerializeField]
    private Button backButton;

    [SerializeField]
    private GameObject panel;

    [SerializeField]
    private RoomListing roomListing;

    private Vector3 defaultPosition;

    [SerializeField]
    private GameObject cityGameObject;

    [SerializeField]
    private RoomSelection roomSelection;

    [SerializeField]
    private GameObject roomObject;
    
	void Start () {
        defaultPosition = panel.transform.position;
        AddListeners ();	
	}

    void OnDestroy() {
        RemoveListeners ();
    }

    void AddListeners() {
        viewVRButton.onClick.AddListener (OnClickViewVirtualReality);
        bookButton.onClick.AddListener (OnClickBook);
        backButton.onClick.AddListener (OnClickBack);
    }

    void RemoveListeners() {
        viewVRButton.onClick.AddListener (OnClickViewVirtualReality);
        bookButton.onClick.AddListener (OnClickBook);
        backButton.onClick.AddListener (OnClickBack);
    }

    public void ShowDetails(Sprite sprite) {
        panel.SetActive (true);
        iTween.ScaleFrom (panel, iTween.Hash ("time", 0.75f, "easetype", iTween.EaseType.spring, "scale", Vector3.zero));
        roomImage.sprite = sprite;
    }

    void OnClickViewVirtualReality() {
        enableVr ();
    }

    void OnClickBook() {

    }

    void OnClickBack() {
        iTween.MoveTo (panel, iTween.Hash ("position", transform.position + (Vector3.left * 1000f), "time", 0.3f, "oncomplete", "OnCompleteAnimation",
          "oncompletetarget", gameObject));
    }

    void OnCompleteAnimation() {
        panel.transform.position = defaultPosition;
        panel.SetActive (false);
        cityGameObject.SetActive (true);
        roomSelection.ShowSelectionPanel ();
        roomObject.SetActive (false);
    }

    IEnumerator LoadDevice(string newDevice, bool enable) {
        VRSettings.LoadDeviceByName (newDevice);
        yield return null;
        VRSettings.enabled = enable;
        PlayerPrefs.SetString (StringConstants.DAYDREAM_KEY, "d");
        PlayerPrefs.Save ();
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }

    void enableVr() {
        StartCoroutine (LoadDevice ("daydream", true));
    }

    void disableVr() {
        StartCoroutine (LoadDevice ("", false));
    }
}
