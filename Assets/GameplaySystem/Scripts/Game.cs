using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Proiect
{
    public class Game : MonoBehaviour
    {
    [SerializeField] Transform prefab;
    [SerializeField] private KeyCode createKey = KeyCode.C;
    [SerializeField] private KeyCode newGameKey = KeyCode.N;
    private Transform playerPos;
    public List<Transform> objects;
    protected Transform env;


        // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        env = GameObject.FindGameObjectWithTag("Environment").transform;
    }

    private void Awake()
    {
        objects = new List<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(createKey))
        {
            CreateObject();
        }
        else if (Input.GetKeyDown(newGameKey))
        {
            BeginNewGame();
        }

    }

    void CreateObject()
    {
        Transform t = Instantiate(prefab);
        t.localPosition = playerPos.localPosition + Random.insideUnitSphere * 5f;
        t.localRotation = Random.rotation;
        t.GetComponent<Renderer>().material.SetColor("_Color", Random.ColorHSV());
        t.transform.parent = env.transform;
        objects.Add(t);
    }

    public void BeginNewGame()
    {
        if (objects.Count > 0)
        {
            for (int i = 0; i < objects.Count; i++)
            {
                Destroy(objects[i].gameObject);
            }
        }

        playerPos.position = new Vector3(0f, 1.8f, 0f);
        playerPos.rotation = new Quaternion(0f, 0f, 0f, 0f);
        objects.Clear();
    }
    }
}
