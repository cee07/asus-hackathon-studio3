using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class Blocker : MonoBehaviour {

	void Start () {
        if (PlayerPrefs.HasKey (StringConstants.DAYDREAM_KEY)) {
            UnityEngine.SceneManagement.SceneManager.LoadScene (2);
        } else
            UnityEngine.SceneManagement.SceneManager.LoadScene (1);
    }

    IEnumerator LoadDevice(string newDevice, bool enable) {
        VRSettings.LoadDeviceByName (newDevice);
        yield return null;
        VRSettings.enabled = enable;
    }

    void enableVr() {
        StartCoroutine (LoadDevice ("daydream", true));
    }

    void disableVr() {
        StartCoroutine (LoadDevice ("", false));
    }
}

public class StringConstants {
    public const string DAYDREAM_KEY = "daydream";
}