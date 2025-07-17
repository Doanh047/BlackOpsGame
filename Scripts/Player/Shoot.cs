using UnityEngine;

public class Shoot : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    static bool isShotting = false;
    public GameObject[] ObjectToEnable;
    public int Ammo = 15;
    public float ReloadTime = 5f;
    private int currentAmmo;
    private float reloadingTime = 0f;
    public bool isReloading = false;
    private AudioSource _reloadSound;

    void Start()
    {
        currentAmmo = Ammo;
        _reloadSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isReloading)
        {
            reloadingTime += Time.deltaTime;
            if (reloadingTime > ReloadTime)
            {
                isReloading = false;
                currentAmmo = Ammo;
            }
            return;
        }

        var click = Input.GetMouseButtonDown(0);

        if (click == true)
        {
            isShotting = true;
            EnableObjects();
        }
        var release = Input.GetMouseButtonUp(0);
        if (release == true)
        {
            isShotting = false;
            DisableObjects();
        }

        if (isShotting == false)
            return;
    }

    private void EnableObjects()
    {
        foreach (var obj in ObjectToEnable)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }

    }

    private void DisableObjects()
    {
        foreach (var obj in ObjectToEnable)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }
    }
    public void Shooting() {
        --currentAmmo;
        Debug.Log("Current ammo: " + currentAmmo);
        if(currentAmmo <= 0)
        {
            isReloading = true;
            reloadingTime = 0f;
            DisableObjects();
            isShotting = false;
            _reloadSound.Play();
        }

    }
}
