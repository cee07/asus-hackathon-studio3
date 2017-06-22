using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    [SerializeField]
    private List<GameObject> blocks = new List<GameObject> ();

    public GameObject GetObjectByIndex(int index) {
        return blocks[index];
    }

    public void Hide() {
        foreach (GameObject go in blocks)
            go.SetActive (false);
    }


}
