using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prison : MonoBehaviour, IInteractable<GameObject> {

    public GameObject gameManager;
    public GameObject noKeyPanel;

    private DemoLevelManager demoLevelManager;

    private void Start()
    {
        demoLevelManager = gameManager.GetComponent<DemoLevelManager>();
    }

	public void Interact(GameObject player)
    {
        if (demoLevelManager.GetHasKey() == true)
        {
            gameManager.GetComponent<GameManager>().SetCurrState((byte)1);
        }
        else
        {
            noKeyPanel.SetActive(true);
        }
    }
}
