using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Main", menuName = "Main", order = 0)]
public class Main : ScriptableObject
{


    [SerializeField] private int _coin = 0;
    public string coinCount;
    public int coin
    {
        get => _coin;
        set
        {
            _coin = value;
            UpdateCoinCount();
        }
    }

    private void UpdateCoinCount()
    {
        coinCount = "Coin : " + _coin;
    }



}
