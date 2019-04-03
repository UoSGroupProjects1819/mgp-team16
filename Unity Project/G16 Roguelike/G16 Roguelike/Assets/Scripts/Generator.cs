﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [Header("Generator Variables")]
    public int width;
    public int height;
    public int numberOfRooms;
    public int gap;
    [Range(1, 3)]
    public int clusterAmount = 1;

    [Header("Read Variables")]
    public List<GameObject> takenRooms = new List<GameObject>();

    [Header("Init Variables")]
    public GameObject roomObj;
    public GameObject[,] rooms;
    public GameObject[] roomTypes;
    public GameObject endRoomObj;
    public GameObject startRoomObj;

    int recurseNum;

    void Start()
    {
        rooms = new GameObject[width,height];

        for (int x = 0; x < rooms.GetLength(0); x++)
        {
            for (int y = 0; y < rooms.GetLength(1); y++)
            {
                GameObject tempRoom = CreateEmptyRoom(new Vector2(x, y));
                tempRoom.GetComponent<Room>().pos = new Vector2(x, y);
                tempRoom.transform.parent = gameObject.transform;
            }
        }

        //Create room and move player
        FillRoomStart(new Vector2(Mathf.RoundToInt(width / 2), Mathf.RoundToInt(width / 2)));
        GameObject.Find("Player").transform.position = new Vector2(Mathf.RoundToInt(width / 2) * gap, Mathf.RoundToInt(width / 2) * gap);
        GameObject.Find("Main Camera").transform.position = new Vector2(Mathf.RoundToInt(width / 2) * gap, Mathf.RoundToInt(width / 2) * gap);

        Invoke("CreateDungeon", 1);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            //CreateDungeon();
        }
    }

    GameObject CreateEmptyRoom(Vector2 pos)
    {
        int x = Mathf.RoundToInt(pos.x);
        int y = Mathf.RoundToInt(pos.y);
        GameObject tempRoom = rooms[x, y] = Instantiate(roomObj, new Vector2(x*gap, y* gap), Quaternion.identity);
        return tempRoom;
    }

    void FillRoom(Vector2 pos)
    {
        int x = Mathf.RoundToInt(pos.x);
        int y = Mathf.RoundToInt(pos.y);
        rooms[x, y].GetComponent<Room>().taken = true;
        takenRooms.Add(rooms[x, y]);
    }

    void FillRoomEnd(Vector2 pos)
    {
        int x = Mathf.RoundToInt(pos.x);
        int y = Mathf.RoundToInt(pos.y);
        rooms[x, y].GetComponent<Room>().endRoom = true;
        rooms[x, y].GetComponent<Room>().taken = true;
        takenRooms.Add(rooms[x, y]);
    }

    void FillRoomStart(Vector2 pos)
    {
        int x = Mathf.RoundToInt(pos.x);
        int y = Mathf.RoundToInt(pos.y);
        rooms[x, y].GetComponent<Room>().startRoom = true;
        rooms[x, y].GetComponent<Room>().taken = true;
        takenRooms.Add(rooms[x, y]);
    }

    public bool IsRoom(Vector2 pos)
    {
        int x = Mathf.RoundToInt(pos.x);
        int y = Mathf.RoundToInt(pos.y);
        if(x >= width)
        {
            return true;
        }
        if(y >= height)
        {
            return true;
        }
        if(rooms[x, y].GetComponent<Room>().taken == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void CreateDungeon()
    {
        recurseNum = 0;
        bool endRoom = false;

        while (recurseNum < numberOfRooms) {
            print(recurseNum);

            if(recurseNum == numberOfRooms/2)
            {
                endRoom = true;
            }
            else
            {
                endRoom = false;
            }

            if(recurseNum > (numberOfRooms - (numberOfRooms/3)) )
            {
                clusterAmount = 3;
            }

            for (int x = 0; x < takenRooms.Count; x++)
            {
                takenRooms[x].GetComponent<Room>().CheckLocked();
            }

            List<int> tempDir = new List<int> { 0, 1, 2, 3 };
            int randInt = Random.Range(0, takenRooms.Count-1);
            Room tempRoom = takenRooms[randInt].GetComponent<Room>();

            int randInt2 = Random.Range(0, tempDir.Count);

            if (tempRoom.GetComponent<Room>().GetDir(randInt2).x <= width || tempRoom.GetComponent<Room>().GetDir(randInt2).y <= height)
            {
                if (tempRoom.GetComponent<Room>().GetDir(randInt2) != new Vector2(-1, -1))
                {
                    tempRoom = rooms[(int)tempRoom.GetComponent<Room>().GetDir(randInt2).x, (int)tempRoom.GetComponent<Room>().GetDir(randInt2).y].GetComponent<Room>();
                    rooms[(int)tempRoom.pos.x, (int)tempRoom.pos.y].GetComponent<Room>().CheckLocked();

                    if (tempRoom.lockedNum <= clusterAmount)
                    {
                        if (endRoom)
                        {
                            FillRoomEnd(tempRoom.pos);
                            print("CREATED ROOM AT" + tempRoom.GetComponent<Room>().GetDir(randInt2));
                            recurseNum++;
                        }

                        FillRoom(tempRoom.pos);
                        print("CREATED ROOM AT" + tempRoom.GetComponent<Room>().GetDir(randInt2));
                        recurseNum++;
                    }
                    else
                    {
                        print("invalid room based on number of neighbors");
                    }
                }
                else
                {
                    print("invalid room after direction chosen");
                }
            }
        }
    }
}