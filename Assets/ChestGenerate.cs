using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestGenerate : MonoBehaviour
{
    private int rand;
    public Sprite[] Sprites;

    // Start is called before the first frame update
    void Start()
    {
        Change();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Change();
        }
    }

    void Change()
    {
        rand = Random.Range(0, Sprites.Length);
        GetComponent<SpriteRenderer>().sprite = Sprites[rand];
    }
}
