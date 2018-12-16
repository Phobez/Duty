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
    public float stunBombRadius;
    private float initialMaxSpeed;

    public byte darts;
    public byte bombs;
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

        hasUsedCloakingDevice = false;

        IsSelected = (byte) 1;
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
            IsSelected = (byte) 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            IsSelected = (byte) 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            IsSelected = (byte) 3;
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            useTool();
        }
    }

    // a method to use selected tool
    private void useTool()
    {
        switch (isSelected)
        {
            case 1:
                ShootDart();
                break;
            case 2:
                Cloak();
                break;
            case 3:
                ThrowStunBomb();
                break;
        }
    }

    // a method to shoot a dart
    private void ShootDart()
    {
        anim.SetBool("Dart", true);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, currDir, 3.0f, enemyLayer);

        if (hit && darts > 0)
        {
            if (!hit.collider.gameObject.GetComponent<EnemyAI>().isJuggernaut)
            {
                hit.collider.SendMessage("Sleep");
            }
            darts--;
        }
        anim.SetBool("Dart", false);
    }

    // a method to use cloaking device
    private void Cloak()
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

    // a method to use stun bomb
    private void ThrowStunBomb()
    {
        if (bombs > 0)
        {
            Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, stunBombRadius, LayerMask.GetMask("Enemy"));

            foreach (Collider2D enemy in enemies)
            {
                enemy.SendMessage("Sleep");
            }

            bombs--;
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

    /////// PROPERTIES ///////
    public byte Darts
    {
        get
        {
            return darts;
        }
    }

    public byte IsSelected
    {
        get
        {
            return isSelected;
        }
        set
        {
            if (this.isSelected >= 1 && this.isSelected <= 3)
            {
                this.isSelected = value;
            }
            else
            {
                this.isSelected = (byte) 1;
                // Debug.Log("ERROR: INVALID INPUT");
            }
        }
    }

    public bool HasUsedCloakingDevice
    {
        get
        {
            return hasUsedCloakingDevice;
        }
    }
}
