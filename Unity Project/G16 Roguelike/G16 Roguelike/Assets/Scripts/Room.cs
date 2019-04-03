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

    public bool spawnedRoom;
    public bool endRoom;
    public bool startRoom;

    void Start()
    {
        gen = GameObject.Find("Generator").GetComponent<Generator>();
        Invoke("LockDoors", 2);
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

        if (taken && !spawnedRoom)
        {
            if (endRoom){
                
                GameObject tempRoom = Instantiate(gen.endRoomObj, transform.position, Quaternion.identity);
                tempRoom.transform.parent = gameObject.transform;
                spawnedRoom = true;
            }
            else if(startRoom)
            {
                GameObject tempRoom = Instantiate(gen.startRoomObj, transform.position, Quaternion.identity);
                tempRoom.transform.parent = gameObject.transform;
                spawnedRoom = true;
            }
            else
            {
                int randInt = Random.Range(0, gen.roomTypes.Length);
                GameObject tempRoom = Instantiate(gen.roomTypes[randInt], transform.position, Quaternion.identity);
                tempRoom.transform.parent = gameObject.transform;
                spawnedRoom = true;
            }
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<PlayerScript>().pos = pos;
        }
    }

    void LockDoors()
    {
        if (!lockedTop && spawnedRoom)
        {
            transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);
        }
        if (!lockedBottom && spawnedRoom)
        {
            transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(2).gameObject.SetActive(false);
            transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(3).gameObject.SetActive(true);
        }
        if (!lockedLeft && spawnedRoom)
        {
            transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(4).gameObject.SetActive(false);
            transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(5).gameObject.SetActive(true);
        }
        if (!lockedRight && spawnedRoom)
        {
            transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).gameObject.SetActive(false);
            transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(7).gameObject.SetActive(true);
        }

        if(transform.childCount == 0)
        {
            Destroy(gameObject);
        }

    }
}