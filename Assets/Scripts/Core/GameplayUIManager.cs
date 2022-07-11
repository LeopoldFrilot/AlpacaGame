using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayUIManager : MonoBehaviour
{
    public GameObject FarmUIObj;
    public GameObject VillageUIObj;
    public GameObject FairUIObj;

    public void SwitchToFarmUI()
    {
        HideAll();
        FarmUIObj.SetActive(true);
    }

    public void SwitchToVillageUI()
    {
        HideAll();
        VillageUIObj.SetActive(true);
    }

    public void SwitchToFairUI()
    {
        HideAll();
        FairUIObj.SetActive(true);
    }

    public void HideAll()
    {
        FarmUIObj.SetActive(false);
        VillageUIObj.SetActive(false);
        FairUIObj.SetActive(false);
    }
}
