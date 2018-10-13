using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolSelect : MonoBehaviour {

    private byte isSelected;

	// Use this for initialization
	void Start() {

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetIsSelected(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetIsSelected(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetIsSelected(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SetIsSelected(4);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            useTool();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            useTool();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            useTool();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            useTool();
        }
    }

    private void useTool()
    {
        switch (isSelected)
        {
            case 1:
                Debug.Log("SKILL 1");
                break;
            case 2:
                Debug.Log("SKILL 2");
                break;
            case 3:
                Debug.Log("SKILL 3");
                break;
            case 4:
                Debug.Log("SKILL 4");
                break;
        }
    }

    public byte GetIsSelected()
    {
        return isSelected;
    }
    public void SetIsSelected(byte isSelected)
    {
        if (isSelected >= 1 && isSelected <= 4)
        {
            this.isSelected = isSelected;
        }
        else
        {
            Debug.Log("CANNOT SET IS SELECTED: INVALID INPUT");
        }
    }
}
