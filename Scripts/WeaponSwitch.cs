using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public GameObject pistol;
    public GameObject knife;
    public GameObject rifle;
    public GameObject shield;

    private bool isShieldActive = false;
    private GameObject lastActiveWeapon = null;

    private void Start()
    {
        if (shield != null)
        {
            shield.SetActive(false);
        }

        if (pistol.activeSelf) lastActiveWeapon = pistol;
        else if (knife.activeSelf) lastActiveWeapon = knife;
        else if (rifle.activeSelf) lastActiveWeapon = rifle;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchWeapon(knife);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchWeapon(pistol);
        }
        if (ArmControllerRifle.isCollect)
        {
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                SwitchWeapon(rifle);
            }
        }



        if (Input.GetMouseButtonDown(1))
        {
            ActivateShield();
        }


        if (Input.GetMouseButtonUp(1))
        {
            DeactivateShield();
        }
    }


    void SwitchWeapon(GameObject weapon)
    {
        if (isShieldActive) DeactivateShield();

        if (lastActiveWeapon != null)
        {
            lastActiveWeapon.SetActive(false);
        }
        weapon.SetActive(true);
        lastActiveWeapon = weapon;
    }
    private void DeactivateAll()
    {
        if (pistol != null) pistol.SetActive(false);
        if (knife != null) knife.SetActive(false);
        if (rifle != null) rifle.SetActive(false);
        if (shield != null) shield.SetActive(false);
        isShieldActive = false;
    }

    void ActivateShield()
    {
        if (shield != null && !isShieldActive)
        {
            
                if (pistol.activeSelf) lastActiveWeapon = pistol;
                else if (knife.activeSelf) lastActiveWeapon = knife;
                else if (rifle.activeSelf) lastActiveWeapon = rifle;
                else lastActiveWeapon = null;


                if (lastActiveWeapon != null)
                {
                    lastActiveWeapon.SetActive(false);
                }
                shield.SetActive(true);
                isShieldActive = true;
            


        }
    }


    void DeactivateShield()
    {
        if (shield != null && isShieldActive)
        {
            shield.SetActive(false);
            isShieldActive = false;


            if (lastActiveWeapon != null)
            {
                lastActiveWeapon.SetActive(true);
            }
        }
    }
    public void pistolSw()
    {
        knife.SetActive(false);
        rifle.SetActive(false);
        pistol.SetActive(true);
        lastActiveWeapon = pistol;
    }
    public void knifeSw()
    {
        knife.SetActive(true);
        rifle.SetActive(false);
        pistol.SetActive(false);
        lastActiveWeapon = knife;
    }
    public void rifleSw()
    {
        if (ArmControllerRifle.isCollect)
        {
            knife.SetActive(false);
            rifle.SetActive(true);
            pistol.SetActive(false);
            lastActiveWeapon = rifle;
        }

    }
}