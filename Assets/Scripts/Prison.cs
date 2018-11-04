using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prison : MonoBehaviour, IInteractable<GameObject> {

    public GameObject gameManager;
    public GameObject noKeyPanel;
    public GameObject fakeKeyPanel;

    private DemoLevelManager demoLevelManager;

    private void Start()
    {
        demoLevelManager = gameManager.GetComponent<DemoLevelManager>();
    }

	public void Interact(GameObject player)
    {
        if (demoLevelManager.GetHasKey() == true)
        {
            GameManager.Instance.Victory(true);
        }
        else if (demoLevelManager.GetHasFakeKey() == true)
        {
            fakeKeyPanel.SetActive(true);
        }
        else
        {
            noKeyPanel.SetActive(true);
        }
    }
}
