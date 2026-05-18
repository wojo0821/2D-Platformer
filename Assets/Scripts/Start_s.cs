using UnityEngine;

public class Start_s : MonoBehaviour
{
    [SerializeField] private Main main = null;
    void Start()
    {
        main.coin = 0;
    }
}
