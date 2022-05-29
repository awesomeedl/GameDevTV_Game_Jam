using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPoint : MonoBehaviour
{
    public static Sprite activatedSprite;
    public static Sprite deactivatedSprite;
    public SpriteRenderer spriteRenderer;

    void Awake() {
        if(activatedSprite == null) {
            activatedSprite = Resources.Load<Sprite>("Image/active_spawn");
            deactivatedSprite = Resources.Load<Sprite>("Image/inactive_spawn");
        }
    }

    public void Activate() {
        spriteRenderer.sprite = activatedSprite;
    }

    public void Deactivate() {
        spriteRenderer.sprite = deactivatedSprite;
    }

}
