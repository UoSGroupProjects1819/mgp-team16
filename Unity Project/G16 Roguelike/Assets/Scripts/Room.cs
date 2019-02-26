using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    [Header("Read Variables")]
    public Vector2 pos;
    public bool taken;
    public Generator gen;
    public bool lockedTop, lockedRight, lockedBottom, lockedLeft;
    public int lockedNum;

    void Start()
    {
        gen = GameObject.Find("Generator").GetComponent<Generator>();
    }

    void Update()
    {
        if (pos.y == gen.height-1)
        {
            lockedTop = true;
        }
        if (pos.x == gen.width-1)
        {
            lockedRight = true;
        }
        if (pos.y == 0)
        {
            lockedBottom = true;
        }
        if (pos.x == 0)
        {
            lockedLeft = true;
        }
        if (taken)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    public Vector2 GetDir(int dir)
    {
        if(dir == 0 && !lockedTop)
        {
            return new Vector2(pos.x, pos.y + 1);
        }
        else if (dir == 1 && !lockedRight)
        {
            return new Vector2(pos.x + 1, pos.y);
        }
        else if (dir == 2 && !lockedBottom)
        {
            return new Vector2(pos.x, pos.y - 1);
        }
        else if (dir == 3 && !lockedLeft)
        {
            return new Vector2(pos.x - 1, pos.y);
        }
        else
        {
            return new Vector2(-1,-1);
        }
    }

    public void CheckLocked()
    {
        if (gen.IsRoom(new Vector2(pos.x, pos.y + 1)))
        {
            lockedTop = true;
        }
        if (gen.IsRoom(new Vector2(pos.x + 1, pos.y)))
        {
            lockedRight = true;
        }
        if (gen.IsRoom(new Vector2(pos.x, pos.y - 1)))
        {
            lockedBottom = true;
        }
        if (gen.IsRoom(new Vector2(pos.x - 1, pos.y)))
        {
            lockedLeft = true;
        }

        lockedNum = 0;
        if (lockedTop)
        {
            lockedNum++;
        }
        if (lockedRight)
        {
            lockedNum++;
        }
        if (lockedBottom)
        {
            lockedNum++;
        }
        if (lockedLeft)
        {
            lockedNum++;
        }


    }
}