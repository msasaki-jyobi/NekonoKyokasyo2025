using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    private GameObject _hpGauge;

    void Start()
    {
        _hpGauge = GameObject.Find("hpGauge");
    }

    public void DecreaseHP()
    {
        _hpGauge.GetComponent<Image>().fillAmount -= 0.1f;
    }
}
