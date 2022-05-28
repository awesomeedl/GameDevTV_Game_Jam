using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPoint : MonoBehaviour
{
    public Sprite activatedSprite;

    public Sprite deactivatedSprite;

    public SpriteRenderer spriteRenderer;
    public void Activate() {
        spriteRenderer.sprite = activatedSprite;
    }

    public void Deactivate() {
        spriteRenderer.sprite = deactivatedSprite;
    }

}
