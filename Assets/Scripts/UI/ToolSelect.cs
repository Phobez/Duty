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
    public float cloakedMaxSpeed;
    private float cloakTimer;
    private float initialMaxSpeed;

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
        isFacingRight = GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().M_FacingRight;

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
            Color tempColor = sprRend.color;
            tempColor.a = 0.5f;
            sprRend.color = tempColor;

            hide.IsCloaked = true;
            hasUsedCloakingDevice = true;
            initialMaxSpeed = GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().M_MaxSpeed;
            GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().M_MaxSpeed = cloakedMaxSpeed;

            StartCoroutine(CTimeCloaking());
        }
    }

    // a general method to count down time
    private bool CountdownTime(ref float timer)
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            return false;
        }
        else
        {
            return true;
        }
    }

    /////// COROUTINES ///////
    // an enumerator to time cloaking
    private IEnumerator CTimeCloaking()
    {
        float cloakTimer = cloakTime;

        while (!CountdownTime(ref cloakTimer))
        {
            yield return 0;
        }

        Color tempColor = sprRend.color;
        tempColor.a = 1f;
        sprRend.color = tempColor;

        hide.IsCloaked = false;
        GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().M_MaxSpeed = initialMaxSpeed;
        yield break;
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
