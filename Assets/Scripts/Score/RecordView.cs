using UnityEngine;
using TMPro;

namespace Score
{
    public class RecordView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI recordText;

        private void Update()
        {
            recordText.text = $"Record: {PlayerPrefs.GetInt("Record")}";
        }            
    }
}