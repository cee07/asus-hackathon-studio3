using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class VREnabler : MonoBehaviour {

    void Start() {
        enableVr ();
        PlayerPrefs.DeleteAll ();
    }

    IEnumerator LoadDevice(string newDevice, bool enable) {
        VRSettings.LoadDeviceByName (newDevice);
        yield return null;
        VRSettings.enabled = enable;
    }

    void enableVr() {
        StartCoroutine (LoadDevice ("daydream", true));
    }
}
