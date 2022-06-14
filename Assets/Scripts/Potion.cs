using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public int PotionSelect = 1;
    public Sprite[] PotionSprite;
    void Start()
    {
        PotionSelect = Random.Range(1, 4); 
        
        // Change sprite
        gameObject.GetComponent<SpriteRenderer>().sprite = PotionSprite[PotionSelect-1];
    }

    void Update()
    {
        OverScreenDestroy();
    }

    void OverScreenDestroy()
    {
        if (transform.position.y > 0)
        {
            return;
        }
        Destroy(gameObject);
    }
}
