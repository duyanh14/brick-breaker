using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] public float minRelativePosX = 1f; // assumes paddle size of 1 relative unit

    [SerializeField] public float maxRelativePosX = 15f; // assumes paddle size of 1 relative unit

    [SerializeField] public float fixedRelativePosY = .64f; // paddle does not move on the Y directiob

    // Unity units of the WIDTH of the screen (e.g. 16)
    [SerializeField] public float screenWidthUnits = 16;

    private float paddleMoveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        float startPosX = ConvertPixelToRelativePosition(screenWidthUnits / 2, Screen.width);
        transform.position = GetUpdatedPaddlePosition(startPosX);
    }

    // Update is called once per frame
    void Update()
    {
        var relativePosX = ConvertPixelToRelativePosition(pixelPosition: Input.mousePosition.x, Screen.width);
        transform.position = Vector2.MoveTowards(transform.position, GetUpdatedPaddlePosition(relativePosX),
            paddleMoveSpeed * Time.deltaTime);
    }

    public Vector2 GetUpdatedPaddlePosition(float relativePosX)
    {
        // clamps the X position
        float clampedRelativePosX = Mathf.Clamp(relativePosX, minRelativePosX, maxRelativePosX);

        Vector2 newPaddlePosition = new Vector2(clampedRelativePosX, fixedRelativePosY);
        return newPaddlePosition;
    }

    public float ConvertPixelToRelativePosition(float pixelPosition, int screenWidth)
    {
        var relativePosition = pixelPosition / screenWidth * screenWidthUnits;
        return relativePosition;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag != "Potion")
        {
            return;
        }

        Potion p = other.gameObject.GetComponent<Potion>();

        Destroy(other.gameObject);

        if (p.PotionSelect == 1)
        {
            touchHeartPotion();
        }
        else if (p.PotionSelect == 2)
        {
            touchGearPotion();
        }
        else if (p.PotionSelect == 3)
        {
            touchBlueBottle();
        }
        else if (p.PotionSelect == 4)
        {
            touchEmptyBottle();
        }
    }

    private void touchHeartPotion()
    {
        var gameSession = GameSession.Instance;
        if (gameSession.PlayerLives >= 5)
        {
            return;
        }

        gameSession.PlayerLives++;
    }

    private DateTime paddleScaleTime;

    private void touchGearPotion()
    {
        paddleScaleTime = DateTime.Now;
        transform.localScale = new Vector3(2, 1, 1);
        StartCoroutine(resetPaddleScale(10.0f));
    }

    IEnumerator resetPaddleScale(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        double s = Math.Abs((DateTime.Now - paddleScaleTime).TotalSeconds);
        if (s < 10)
        {
            StartCoroutine(resetPaddleScale((float) s));
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private DateTime paddleMoveSpeedTime;
    private int touchBlueBottleN = 0;

    private void touchBlueBottle()
    {
        if (touchBlueBottleN == 2)
        {
            return;
        }

        if (touchBlueBottleN == 1)
        {
            double s = Math.Abs((DateTime.Now - paddleMoveSpeedTime).TotalSeconds);
            if (s < 5)
            {
                return;
            }
        }

        paddleMoveSpeed += (float) (5 * 0.3);
        touchBlueBottleN += 1;
        paddleMoveSpeedTime = DateTime.Now;
        if (touchBlueBottleN == 1)
        {
            StartCoroutine(resetPaddleMoveSpeed(10.0f));
        }
        Debug.Log("paddleMoveSpeed "+paddleMoveSpeed);
    }

    IEnumerator resetPaddleMoveSpeed(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Debug.Log(123);
        if (touchBlueBottleN > 0)
        {
            paddleMoveSpeed -= (float) (5 * 0.3);
            touchBlueBottleN -= 1;
            double s = Math.Abs((DateTime.Now - paddleMoveSpeedTime).TotalSeconds);
            if (s < 10)
            {
                StartCoroutine(resetPaddleMoveSpeed((float) s));
            }
            Debug.Log("paddleMoveSpeed "+paddleMoveSpeed);
        }
    }

    private void touchEmptyBottle()
    {
        paddleMoveSpeed = 5;
        touchBlueBottleN = 0;
        
        transform.localScale = new Vector3(1, 1, 1);
    }
}