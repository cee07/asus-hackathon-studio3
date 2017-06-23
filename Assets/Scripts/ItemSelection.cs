using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSelection : MonoBehaviour {

    public RectTransform content;


    private bool isScrollingRight;
    private float lerpValue;
    private Vector3 currentPos;
    private Vector3 newPos;

    void Start()
    {
        gameObject.SetActive(false);
        isScrollingRight = false;
        lerpValue = 1;
        currentPos = newPos = content.anchoredPosition;
    }

    private void Update()
    {
        if (lerpValue < 1)
        {
            lerpValue += Time.deltaTime * 8;
            content.anchoredPosition = Vector2.Lerp(currentPos, newPos, lerpValue);
        }
    }

    public void MoveLeft()
    {
        //content.anchoredPosition = new Vector2(content.anchoredPosition.x - 1000, content.anchoredPosition.y);
        isScrollingRight = false;
        lerpValue = 0;
        currentPos = content.anchoredPosition;
        newPos = new Vector2(content.anchoredPosition.x - 650, content.anchoredPosition.y);
    }

    public void MoveRight()
    {
        //content.anchoredPosition = new Vector2(content.anchoredPosition.x + 1000, content.anchoredPosition.y);
        isScrollingRight = true;
        lerpValue = 0;
        currentPos = content.anchoredPosition;
        newPos = new Vector2(content.anchoredPosition.x + 650, content.anchoredPosition.y);
    }

    public void ShowInFrontOfPlayer()
    {
        transform.position = Camera.main.transform.position + (Camera.main.transform.forward * 2);
        transform.eulerAngles = Camera.main.transform.eulerAngles;//new Vector3(Camera.main.transform.eulerAngles.x, Camera.main.transform.eulerAngles.y + 180, Camera.main.transform.eulerAngles.z); 
    }
}
