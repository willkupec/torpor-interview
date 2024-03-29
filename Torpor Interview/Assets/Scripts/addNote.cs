﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


public class addNote : MonoBehaviour
{
    public InputField input;
    public TextAsset output;
    public GameObject bullet;
    public Transform bulletParent;
    private string path;
    private Vector3 lastBulletPos = new Vector3(-7, 3.75f, 0);
    private GameObject bulletObj;

    //data used for json
    public class inputData
    {
        public string inputText;
    }


    public void addInput()
    {
       
        //check to see current act and "act" hehe, accordingly
        if (GameObject.Find("Act1") != null)
        {
            bulletParent = GameObject.Find("Act1").transform;
            path = @"C:\Users\Admin\Documents\GitHub\torpor-interview\Torpor Interview\Assets\JSON\act1.json";
            Debug.Log("Act1");
        }
        else if (GameObject.Find("Act2") != null)
        {
            bulletParent = GameObject.Find("Act2").transform;
            path = @"C:\Users\Admin\Documents\GitHub\torpor-interview\Torpor Interview\Assets\JSON\act2.json";
            Debug.Log("Act2");
        }
        else if (GameObject.Find("Act3") != null)
        {
            bulletParent = GameObject.Find("Act3").transform;
            path = @"C:\Users\Admin\Documents\GitHub\torpor-interview\Torpor Interview\Assets\JSON\act3.json";
            Debug.Log("Act3");
        }
        else if (GameObject.Find("Act4") != null)
        {
            bulletParent = GameObject.Find("Act4").transform;
            path = @"C:\Users\Admin\Documents\GitHub\torpor-interview\Torpor Interview\Assets\JSON\act4.json";
            Debug.Log("Act4");
        }
        //create json data
        inputData data = new inputData();
        data.inputText = input.text;

        string json = JsonUtility.ToJson(data);
       
        File.WriteAllText(path, json);
        Debug.Log("Written");

        //retrieve json data
        json = File.ReadAllText(path);
        data = JsonUtility.FromJson<inputData>(json);
        Debug.Log("Read");

        //create bullet object from prefab
        //use last y-value to determine position
        //instantiate as child of Act Object
        bulletObj = Instantiate(bullet) as GameObject;
        bulletObj.transform.position = lastBulletPos;
        bulletObj.transform.rotation = transform.rotation;
        bulletObj.transform.SetParent(bulletParent);
        bulletObj.transform.GetChild(0).GetComponent<Text>().text = data.inputText;


            Debug.Log(lastBulletPos);
        lastBulletPos.y = lastBulletPos.y - 1;

        

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(bulletObj.GetComponent<Button>().enabled)
        {
            //lastBulletPos = new Vector3(-7, 3.75f, 0);
        }
        */
    }
}
