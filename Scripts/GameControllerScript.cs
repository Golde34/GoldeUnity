using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;


public class GameControllerScript : MonoBehaviour
{
    public GameObject boxPrefab;
    public List<GameObject> boxPrefabs = new List<GameObject>();
    public Location[] locationPoints;
    public Location[] hiddingBoxLocation;
    public Location[] treasureboxLocation;
    public Location[] emptyBoxLocation;

    void getLocationList()
    {
        var jsonTextFile = Resources.Load<TextAsset>("Text/boxLocation");
        Debug.Log(jsonTextFile.text);
        locationPoints = JsonHelper.FromJson<Location>(jsonTextFile.text);
        Debug.Log(locationPoints.Length);
    }

    void randomSize(int locationLength, int hiddingboxLength, int treasureboxLength, int emptyboxLength)
    {
        //int randomBoxlength = Random.Range(0, locationLength);
        hiddingboxLength = Random.Range(86, 192);
        locationLength -= hiddingboxLength;
        treasureboxLength = Random.Range(0, locationLength);
        emptyboxLength = locationLength - treasureboxLength;
    }

    void randomBox()
    {
        int hiddingBoxLength = 0;
        int treasureBoxLength = 0;
        int emptyBoxLength = 0;
        int locationLength = locationPoints.Length;
        hiddingBoxLength = Random.Range(86, 192);
        locationLength -= hiddingBoxLength;
        treasureBoxLength = Random.Range(10, locationLength);
        emptyBoxLength = locationLength - treasureBoxLength;

        for (int i = 0; i < treasureBoxLength; i++)
        {
            int randomIndex = Random.Range(0, locationPoints.Length - 1);
            Location location = locationPoints[randomIndex];
            treasureboxLocation.Append(location);
            locationPoints = locationPoints.Where(p => p != location).ToArray();
        }
        for (int i = 0; i < hiddingBoxLength; i++)
        {
            int randomIndex = Random.Range(0, locationPoints.Length - 1);
            Location location = locationPoints[randomIndex];
            hiddingBoxLocation.Append(location);
            locationPoints = locationPoints.Where(p => p != location).ToArray();
        }
        for (int i = 0; i < emptyBoxLength; i++)
        {
            int randomIndex = Random.Range(0, locationPoints.Length - 1);
            Location location = locationPoints[randomIndex];
            emptyBoxLocation.Append(location);
            locationPoints = locationPoints.Where(p => p != location).ToArray();
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        getLocationList();
        //Then use JsonUtility.FromJson<T>() to deserialize jsonTextFile into an object 
        randomBox();
        Debug.Log("treasure: " + treasureboxLocation.Length);
        Debug.Log("empty: " + emptyBoxLocation.Length);
        Debug.Log("hidding: " + hiddingBoxLocation.Length);

        for (int i = 0; i < hiddingBoxLocation.Length; i++)
        {
            GameObject box = Instantiate(boxPrefab, new Vector2(locationPoints[i].x, locationPoints[i].y), Quaternion.identity);
            boxPrefabs.Add(box);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}
[Serializable]
public class Location
{
    public float x;
    public float y;
}