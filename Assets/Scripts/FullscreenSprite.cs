using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullscreenSprite : MonoBehaviour {

    private void Awake()
    {
        SpriteRenderer sprRend = GetComponent<SpriteRenderer>();

        float cameraHeight = Camera.main.orthographicSize * 2;
        Vector2 cameraSize = new Vector2(Camera.main.aspect * cameraHeight, cameraHeight);
        Vector2 spriteSize = sprRend.sprite.bounds.size;

        Vector2 scale = transform.localScale;
        if (cameraSize.x >= cameraSize.y)
        {
            // Landscape (or equal)
            scale *= cameraSize.x / spriteSize.y;
        }
        else
        {
            // Portrait
            scale *= cameraSize.y / spriteSize.y;
        }

        transform.position = Vector2.zero;
        transform.localScale = scale;
    }
}
