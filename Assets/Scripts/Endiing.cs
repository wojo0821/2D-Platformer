using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Endiing : MonoBehaviour
{
    [SerializeField] private UIDocument uiDocument;
    void Start()
    {
        uiDocument.rootVisualElement.Q<Label>("END").style.display = DisplayStyle.None;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        uiDocument.rootVisualElement.Q<Label>("END").style.display = DisplayStyle.Flex;

    }
}
