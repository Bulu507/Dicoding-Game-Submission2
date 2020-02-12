using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public string PlayerGround;
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            PlayerController.IsJump = false;
        }

        if (coll.gameObject.name == "Ball")
        {
            if (PlayerGround.Equals("Player1"))
            {
                GameController.P2Point += 1;
            }
            else if (PlayerGround.Equals("Player2"))
            {
                GameController.P1Point += 1;
            }

            GameController.ballPlayer = PlayerGround;
            GameController.IsReset = true;
            GameController.ShowInfo = true;
        }
    }
}
