using System;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool Killed = false;
    public GameObject[] EnableWhenKilled;
    public GameObject[] DisableWhenKilled;
    private Component[] _components;
    public float TimeBeforeDestroy = 5f;
    private bool _died = false;
    void Start()
    {
        _components = GetComponents<Component>();
    }

    // Update is called once per frame
    void Update()
    {

        if (_died)
        {
            TimeBeforeDestroy -= Time.deltaTime;
        }
        if (TimeBeforeDestroy <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Bullet"))
        {
            foreach (GameObject obj in EnableWhenKilled)
            {
                obj.SetActive(true);
            }
            foreach (GameObject obj in DisableWhenKilled)
            {
                obj.SetActive(false);
                foreach (var component in _components)
                {
                    if ( component is MonoBehaviour monoBehaviour)
                    {
                        //Debug.Log("Disabling MonoBehaviour: " + monoBehaviour.GetType().Name);
                        if (monoBehaviour.GetType().Name != "EnemyCollision")
                        monoBehaviour.enabled = false; // Disable all MonoBehaviours on the player
                    }
                }
            }
            _died = true;
        }
    }
}
