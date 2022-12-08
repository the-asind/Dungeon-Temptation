using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAvatar : MonoBehaviour
{
    public Image AvatarSprite;
    public SpriteRenderer PlayerSprite; 
    void Start()
    {
        AvatarSprite = GetComponent<Image>();
        AvatarSprite.sprite = PlayerSprite.sprite;
    }
}
