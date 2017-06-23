using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {
    
	public List<GameObject> itemPool =  new List<GameObject>();
	private int mask;

    private GvrLaserPointer laserPointer;
    private Item instantiatedItem;

    private Color32 validPlaceColor;
    private Color32 invalidPlaceColor;
    private Color32 normalLaserColor;

    // Use this for initialization
    void Start () {
        laserPointer = GameObject.Find("Player").transform.Find("GvrControllerPointer/Laser").GetComponent<GvrLaserPointer>();
        mask = 1 << 8 | 1 << 9 | 1 << 10;

        validPlaceColor = new Color32(0, 255, 0, 240);
        invalidPlaceColor = new Color32(255, 0, 0, 240);
        normalLaserColor = new Color32(255, 255, 255, 128);
    }
	
	// Update is called once per frame
	void Update () {
        /*
		Debug.DrawRay(transform.position, transform.forward, Color.green);

		if (Input.GetKeyDown (KeyCode.A)) {
			SpawnItem (0);
		}

		if (Input.GetKeyDown (KeyCode.S)) {
			SpawnItem (1);
		}

		if (Input.GetKeyDown (KeyCode.D)) {
			SpawnItem (2);
		}

		if (Input.GetKeyDown (KeyCode.Z)) {
			RemoveItem (0);
		}

		if (Input.GetKeyDown (KeyCode.X)) {
			RemoveItem (1);
		}

		if (Input.GetKeyDown (KeyCode.C)) {
			RemoveItem (2);
		}

		if (Input.GetKeyDown (KeyCode.Q)) {
			TurnItemClockwise (0);
		}

		if (Input.GetKeyDown (KeyCode.W)) {
			TurnItemClockwise (1);
		}

		if (Input.GetKeyDown (KeyCode.E)) {
			TurnItemClockwise (2);
		}

		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			TurnItemCounterClockwise (0);
		}

		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			TurnItemCounterClockwise (1);
		}

		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			TurnItemCounterClockwise (2);
		}
        */
        if (instantiatedItem != null) {
            RaycastHit hit;
            
            if (instantiatedItem.floorItem)
            {
                // Floor Item
                if (Physics.Raycast(laserPointer.transform.position, laserPointer.transform.forward, out hit, Mathf.Infinity, mask))
                {
                    if (hit.transform.gameObject.layer == 10 || hit.transform.gameObject.layer == 9)
                    {
                        Debug.LogError("OBJECT!");
                        laserPointer.laserColor = invalidPlaceColor;

                        if (GvrController.ClickButtonDown)
                        {
                            GameObject.Find("VrPopupMsgCanvas").GetComponent<VrPopupMsg>().ShowMsg("INVALID POSITION");
                        }
                    }
                    else
                    {
                        laserPointer.laserColor = validPlaceColor;

                        if (GvrController.ClickButtonDown) {
                            instantiatedItem.GetComponent<Animator>().SetTrigger("Reset");
                            //itemPool [itemIndex].GetComponent<Rigidbody> ().isKinematic = false;
                            instantiatedItem.transform.position = hit.point;
                            instantiatedItem.gameObject.SetActive(true);
                            //itemPool [itemIndex].GetComponent<Animator> ().enabled = true;
                            instantiatedItem.GetComponent<Animator>().SetTrigger("PopUp");
                            //StartCoroutine(SetKinematicCoroutine(itemPool[itemIndex].GetComponent<Rigidbody>()));

                            instantiatedItem = null;
                            laserPointer.laserColor = normalLaserColor;
                        }
                    }
                }
            }
            else
            {
                // Wall Item
                if (Physics.Raycast(laserPointer.transform.position, laserPointer.transform.forward, out hit, Mathf.Infinity, mask))
                {
                    if (hit.transform.gameObject.layer == 10 || hit.transform.gameObject.layer == 8)
                    {
                        Debug.LogError("OBJECT!");
                        laserPointer.laserColor = invalidPlaceColor;

                        if (GvrController.ClickButtonDown)
                        {
                            GameObject.Find("VrPopupMsgCanvas").GetComponent<VrPopupMsg>().ShowMsg("INVALID POSITION");
                        }
                    }
                    else
                    {
                        laserPointer.laserColor = validPlaceColor;

                        if (GvrController.ClickButtonDown)
                        {
                            instantiatedItem.GetComponent<Animator>().SetTrigger("Reset");
                            instantiatedItem.transform.position = hit.point;
                            instantiatedItem.transform.rotation = hit.transform.rotation;
                            instantiatedItem.gameObject.SetActive(true);
                            //itemPool [itemIndex].GetComponent<Animator> ().enabled = true;
                            instantiatedItem.GetComponent<Animator>().SetTrigger("PopUp");

                            instantiatedItem = null;
                            laserPointer.laserColor = normalLaserColor;
                        }
                    }
                }
            }
        }
	}

    public void InstantiateItem(GameObject itemPrefab) {
        GameObject go = Instantiate<GameObject>(itemPrefab);
        instantiatedItem = go.GetComponent<Item>();
        instantiatedItem.transform.position = new Vector3(100, 100, 100);
    }

	public void SpawnItem(int itemIndex) {
		//items [itemIndex].transform.position;
		RaycastHit hit;
		mask = 1 << 8 | 1 << 9 | 1 << 10;

		itemPool [itemIndex].GetComponent<Animator> ().SetTrigger ("Reset");

		if (itemPool [itemIndex].GetComponent<Item>().floorItem) {
			// Floor Item
			if (Physics.Raycast (laserPointer.transform.position, laserPointer.transform.forward, out hit, Mathf.Infinity, mask)) {
				if (hit.transform.gameObject.layer == 10 || hit.transform.gameObject.layer == 9) {
					Debug.LogError ("OBJECT!");
				} else {
					//itemPool [itemIndex].GetComponent<Rigidbody> ().isKinematic = false;
					itemPool [itemIndex].transform.position = hit.point;
					itemPool [itemIndex].SetActive (true);
					//itemPool [itemIndex].GetComponent<Animator> ().enabled = true;
					itemPool [itemIndex].GetComponent<Animator> ().SetTrigger ("PopUp");
					//StartCoroutine(SetKinematicCoroutine(itemPool[itemIndex].GetComponent<Rigidbody>()));
				}
			}
		} else {
			// Wall Item
			if (Physics.Raycast (laserPointer.transform.position, laserPointer.transform.forward, out hit, Mathf.Infinity, mask)) {
				if (hit.transform.gameObject.layer == 10 || hit.transform.gameObject.layer == 8) {
					Debug.LogError ("OBJECT!");
				} else {
					itemPool [itemIndex].transform.position = hit.point;
					itemPool [itemIndex].transform.rotation = hit.transform.rotation;
					itemPool [itemIndex].SetActive (true);
					//itemPool [itemIndex].GetComponent<Animator> ().enabled = true;
					itemPool [itemIndex].GetComponent<Animator> ().SetTrigger ("PopUp");
				}
			}
		}
	}

	public void TurnItemClockwise(int itemIndex) {
		if (!itemPool [itemIndex].GetComponent<Item> ().floorItem)
			return;

		int tIndex = itemPool [itemIndex].GetComponent<Item> ().turnIndex;
		itemPool [itemIndex].GetComponent<Animator> ().SetInteger ("TurnIndex", tIndex);
		itemPool [itemIndex].GetComponent<Animator> ().SetTrigger ("TurnClockwise");
		tIndex++;
		if (tIndex == 4)
			tIndex = 0;
		itemPool [itemIndex].GetComponent<Item> ().turnIndex = tIndex;
	}

	public void TurnItemCounterClockwise(int itemIndex) {
		if (!itemPool [itemIndex].GetComponent<Item> ().floorItem)
			return;

		int tIndex = itemPool [itemIndex].GetComponent<Item> ().turnIndex;
		itemPool [itemIndex].GetComponent<Animator> ().SetInteger ("TurnIndex", tIndex);
		itemPool [itemIndex].GetComponent<Animator> ().SetTrigger ("TurnCounterClockwise");
		tIndex--;
		if (tIndex == -1)
			tIndex = 3;
		itemPool [itemIndex].GetComponent<Item> ().turnIndex = tIndex;
	}

	public void RemoveItem(int itemIndex) {
		itemPool [itemIndex].GetComponent<Item> ().turnIndex = 0;
		itemPool [itemIndex].GetComponent<Animator> ().SetTrigger ("Reset");
		itemPool [itemIndex].SetActive (false);

	}

	IEnumerator SetKinematicCoroutine(Rigidbody rBody) {
		yield return new WaitForSeconds (0.3f);
		rBody.isKinematic = true;
	}
}
