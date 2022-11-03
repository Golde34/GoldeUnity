using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;
using Assets.Scripts.Object;

public class GameControllerScript : MonoBehaviour
{
    public GameObject boxPrefab;
    public List<GameObject> boxPrefabs = new List<GameObject>();
    public Location[] locationPoints;
    private List<Location> virtualBoxes = new List<Location>();
    public List<Location> hiddingBoxLocation;
    public List<Location> treasureboxLocation;
    public List<Location> emptyBoxLocation;

    private void getLocationList()
    {
        var jsonTextFile = Resources.Load<TextAsset>("Text/boxLocation");
        Debug.Log(jsonTextFile.text);
        locationPoints = JsonHelper.FromJson<Location>(jsonTextFile.text);
        Debug.Log(locationPoints.Length);
    }

    public int GetTotalTreasure(int totalTreasure)
    {
        totalTreasure = treasureboxLocation.Count;
        return totalTreasure;
    }
    protected void randomBox()
    {
        int hiddingBoxLength = 0;
        int treasureBoxLength = 0;
        int emptyBoxLength = 0;
        int locationLength = locationPoints.Length;
        hiddingBoxLength = Random.Range(120, 192);
        locationLength -= hiddingBoxLength;
        treasureBoxLength = Random.Range(30, locationLength);
        emptyBoxLength = locationLength - treasureBoxLength;
        //hiddingBoxLength = Random.Range(1, 3);
        //locationLength -= hiddingBoxLength;
        //treasureBoxLength = 1;
        //emptyBoxLength = 0;

        // set temp locations boxs
        for (int i = 0; i < locationPoints.Length; i++)
        {
            virtualBoxes.Add(locationPoints[i]);
        }

        for (int i = 0; i < treasureBoxLength; i++)
        {
            int randomIndex = Random.Range(0, locationPoints.Length - 1);
            Location location = locationPoints[randomIndex];
            treasureboxLocation.Add(location);
            locationPoints = locationPoints.Where(p => p != location).ToArray();
        }
        for (int i = 0; i < hiddingBoxLength; i++)
        {
            int randomIndex = Random.Range(0, locationPoints.Length - 1);
            Location location = locationPoints[randomIndex];
            hiddingBoxLocation.Add(location);
            locationPoints = locationPoints.Where(p => p != location).ToArray();
        }
        for (int i = 0; i < emptyBoxLength; i++)
        {
            int randomIndex = Random.Range(0, locationPoints.Length - 1);
            Location location = virtualBoxes[randomIndex];
            emptyBoxLocation.Add(location);
            locationPoints = locationPoints.Where(p => p != location).ToArray();
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        getLocationList();

        randomBox();

        Debug.Log("treasure: " + treasureboxLocation.ToArray().Length);
        Debug.Log("empty: " + emptyBoxLocation.ToArray().Length);
        Debug.Log("hidding: " + hiddingBoxLocation.ToArray().Length);
        Debug.Log("all points: " + virtualBoxes.ToArray().Length);

        //for (int i = 0; i < virtualBoxes.ToArray().Length; i++)
        //{
        //    GameObject box = Instantiate(boxPrefab, new Vector2(virtualBoxes.ToArray()[i].x, virtualBoxes.ToArray()[i].y), Quaternion.identity);
        //    boxPrefabs.Add(box);
        //}

        for (int i = 0; i < emptyBoxLocation.ToArray().Length; i++)
        {
            GameObject box = Instantiate(boxPrefab, new Vector2(emptyBoxLocation.ToArray()[i].x, emptyBoxLocation.ToArray()[i].y), Quaternion.identity);
            BoxScript boxScript = box.GetComponent<BoxScript>();
            boxScript.type = "empty";
            boxPrefabs.Add(box);
        }

        for (int i = 0; i < treasureboxLocation.ToArray().Length; i++)
        {
            GameObject box = Instantiate(boxPrefab, new Vector2(treasureboxLocation.ToArray()[i].x, treasureboxLocation.ToArray()[i].y), Quaternion.identity);
            BoxScript boxScript = box.GetComponent<BoxScript>();
            boxScript.type = "money";
            boxPrefabs.Add(box);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}