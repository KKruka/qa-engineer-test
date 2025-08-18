using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Submit : MonoBehaviour
{
    [field: SerializeField]
    public Button submitButton { get; private set; }
    
    [field: SerializeField]
    public TextMeshProUGUI countText { get; private set; }
    
    private int count = 0;
    
    private void Start()
    {
        submitButton.onClick.AddListener(OnSubmit);
        UpdateCountText();
    }
    
    public void OnSubmit()
    {
        count++;
        UpdateCountText();
    }
    
    private void UpdateCountText()
    {
        countText.text = count.ToString();
    }
}
