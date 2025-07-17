using UnityEngine;

public class Point : MonoBehaviour
{
    private int _currentPoint;
    public int InitialPoint = 600;
    public float TimePerPoint = 1;
    private float _currentTime;
    void Start()
    {
        _currentPoint = InitialPoint;
    }

    // Update is called once per frame
    void Update()
    {
        _currentTime += Time.deltaTime;
        if(_currentTime > TimePerPoint && _currentPoint > 0)
        {
            --_currentPoint;
            PlayerPrefs.SetInt("Score", GetPoint());
            _currentTime = 0;
        }
    }

    public int GetPoint()
    {
        return _currentPoint;
    }

    public void Died()
    {
        _currentPoint = -1;
        PlayerPrefs.SetInt("Score", GetPoint());
    }
}
