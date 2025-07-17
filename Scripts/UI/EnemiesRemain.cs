using TMPro;
using UnityEngine;

public class EnemiesRemain : MonoBehaviour
{
    public TextMeshProUGUI _current;
    public EnemiesCounter EnemiesCounter;
    private int maxEnemiesCount;
    void Start()
    {
        maxEnemiesCount = EnemiesCounter.EnemiesCount();
    }

    // Update is called once per frame
    void Update()
    {
        if (_current == null)
        {
            Debug.LogError("_current is NULL! Did you forget to assign it in the Inspector?");
            return;
        }
        _current.text = "Enemies: " + EnemiesCounter.EnemiesCount();
    }
}
