using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

//Class for different useful debugs (ex: deal damage, heal, spawn objects etc.)

namespace Proiect.Player.DebugUtils
{
    public class DebugUtils : MonoBehaviour
    {
        [SerializeField] Transform prefab;
        [SerializeField] private KeyCode createKey = KeyCode.C;
        [SerializeField] private KeyCode newGameKey = KeyCode.N;
        private Transform playerPos;
        public List<Transform> objects;
        protected Transform env;
        private KeyCode dmgPlayer = KeyCode.K;
        private KeyCode healPlayer = KeyCode.H;


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

            if (Input.GetKeyDown(dmgPlayer))
            {
                PlayerManager.DamagePlayer(5);
            }
            if (Input.GetKeyDown(healPlayer))
            {
                PlayerManager.HealPlayer(5);
            }
        }

        void CreateObject()
        {
            Transform t = Instantiate(prefab);
            t.localPosition = playerPos.localPosition + Random.insideUnitSphere * 5f;
            t.localRotation = Random.rotation;
            t.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.red);
            t.transform.parent = env.transform;
            objects.Add(t);
        }

        public void CreateList(List<Transform> lista, float[][] colors)
        {
            objects = new List<Transform>();
            env = GameObject.FindGameObjectWithTag("Environment").transform;
            for (int i = 0; i < lista.Count; i++)
            {
                Transform t = Instantiate(prefab);
                t.position = lista[i].position;
                t.rotation = lista[i].rotation;
                t.GetComponent<MeshRenderer>().material.color =
                    new Color(colors[i][3], colors[i][2], colors[i][1], colors[i][0]);
                t.transform.parent = env.transform;
                objects.Add(t);
            }
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

