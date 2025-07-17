using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool Killed = false;
    public GameObject[] EnableWhenKilled;
    public GameObject[] DisableWhenKilled;
    private Component[] _components;
    public GameObject Shield;
    public float ShieldDuration = 1f;
    public int ShieldMaxCollisions = 10;
    private float _shieldActivationTime;
    public Material _lastShield;
    public float TimeBeforeDestroy = 5f;
    public Point Point;
    void Start()
    {
        _components = GetComponents<Component>();
        Point = GetComponent<Point>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Killed)
        {
            TimeBeforeDestroy -= Time.deltaTime;
        }
        if (TimeBeforeDestroy <= 0)
        {
            Point.Died();
            SceneManager.LoadScene("GameOver");
        }
        if (Shield.activeSelf)
        {
            _shieldActivationTime += Time.deltaTime;
            if (_shieldActivationTime > ShieldDuration)
            {
                Shield.SetActive(false);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Bullet"))
        {
           if(ShieldMaxCollisions > 0 )
           {
                if (Shield.activeSelf)
                    return;
                Shield.SetActive(true);
                --ShieldMaxCollisions;
                _shieldActivationTime = 0f;
                if(ShieldMaxCollisions ==1 )
                {
                    Shield.GetComponent<MeshRenderer>().SetMaterials(new List<Material>() { _lastShield });
                }
                Debug.Log($"Shield activated. Remaining collisions: {ShieldMaxCollisions}");
            } else WhenKilled();
        }
    }

    private void WhenKilled()
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
                if (component is MonoBehaviour monoBehaviour)
                {
                    if (monoBehaviour.GetType().Name != "PlayerCollision")
                        monoBehaviour.enabled = false; // Disable all MonoBehaviours on the player
                }
            }
        }
        Killed = true;
    }
}
