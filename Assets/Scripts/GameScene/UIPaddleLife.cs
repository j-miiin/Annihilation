using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPaddleLife : MonoBehaviour
{
    private Sprite[] _lifeSprite;
    private void Awake()
    {
        _lifeSprite = new Sprite[]
        {
            Resources.Load<Sprite>("Image/BallImage/DefaultBall"),
            Resources.Load<Sprite>("Image/BallImage/CheeseBall")
        };

        PaddleType paddleType = GameManager.Instance.GetPaddleType();
        gameObject.GetComponent<SpriteRenderer>().sprite = _lifeSprite[(int)paddleType];
    }
}
