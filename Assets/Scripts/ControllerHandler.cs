using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerHandler : MonoBehaviour
{
    [SerializeField]
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        int xDir = 0;
        int yDir = 0;

        if(Input.GetKey(KeyCode.UpArrow))
        {
            yDir++;
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            yDir--;
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            xDir--;
        }
        if(Input.GetKey (KeyCode.RightArrow))
        {
            xDir++;
        }

        Vector3 newDirection = new Vector3(xDir, 0, yDir);

        if(xDir != 0 || yDir != 0)
        {
            player.Move(newDirection, Time.deltaTime);
        }

        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            player.Shoot(true);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            player.Shoot(false);
        }
    }
}
