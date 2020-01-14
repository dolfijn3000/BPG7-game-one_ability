using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolowSprite : MonoBehaviour
{

    public Transform player;

    private void FixedUpdate()
    {

        transform.position = new Vector3(player.position.x, player.position.y, -10);
    }
}

