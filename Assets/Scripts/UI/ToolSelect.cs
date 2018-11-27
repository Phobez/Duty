using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolSelect : MonoBehaviour {

    /*
     * SKILLS:
     * 1. DART
     * 2. CLOAKING DEVICE
     */

    private Animator anim;

    private SpriteRenderer sprRend;

    private Hide hide;

    private Vector2 currDir;

    public float cloakTime;
    private float cloakTimer;

    public byte darts = 1;
    private byte isSelected;

    private bool isFacingRight;
    private bool hasUsedCloakingDevice;

    private int enemyLayer;

	// Use this for initialization
	void Start() {
        anim = GetComponent<Animator>();

        sprRend = GetComponent<SpriteRenderer>();

        hide = GetComponent<Hide>();

        enemyLayer = LayerMask.GetMask("Enemy");

        cloakTimer = cloakTime;

        hasUsedCloakingDevice = false;

        SetIsSelected(1);
    }
	
	// Update is called once per frame
	void Update () {
        isFacingRight = GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().GetM_FacingRight();

        if (isFacingRight)
        {
            currDir = Vector2.right;
        }
        else
        {
            currDir = Vector2.left;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetIsSelected(1);
            Debug.Log("Skill 1 selected!");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetIsSelected(2);
            Debug.Log("Skill 2 selected!");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetIsSelected(3);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            useTool();
        }

        if (hasUsedCloakingDevice && cloakTimer > 0)
        {
            cloakTimer -= Time.deltaTime;
        }
        else if (hasUsedCloakingDevice && cloakTimer <= 0)
        {
            sprRend.enabled = true;
            hide.IsCloaked = false;
            cloakTimer = 0;
        }
    }

    private void useTool()
    {
        switch (isSelected)
        {
            case 1:
                Skill1();
                break;
            case 2:
                Skill2();
                break;
            case 3:
                Debug.Log("SKILL 3");
                break;
        }
    }

    void Skill1()
    {
        anim.SetBool("Dart", true);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, currDir, 3.0f, enemyLayer);

        if (hit && darts > 0)
        {
            EnemyAI enemy = hit.transform.gameObject.GetComponent<EnemyAI>();
            enemy.CurrState = EnemyAI.EnemyState.ASLEEP;
            darts--;
        }
        anim.SetBool("Dart", false);
    }

    void Skill2()
    {
        if (!hasUsedCloakingDevice)
        {
            sprRend.enabled = false;
            hide.IsCloaked = true;
            hasUsedCloakingDevice = true;
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

    /////// PROPERTIES ///////
    public byte Darts
    {
        get
        {
            return darts;
        }
    }
}
