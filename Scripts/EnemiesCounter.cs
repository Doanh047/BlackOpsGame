using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemiesCounter : MonoBehaviour
{
    public GameObject EnemiesContainer;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public int EnemiesCount()
    {
        if (EnemiesContainer == null)
        {
            return 0;
        }

        int count = 0;
        foreach (Transform child in EnemiesContainer.transform)
        {
            if (child.gameObject.activeSelf)
            {
                count++;
            }
        }
        if (count == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        return count;
    }
}
