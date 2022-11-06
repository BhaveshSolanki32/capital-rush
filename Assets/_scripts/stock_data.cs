using UnityEngine;
using UnityEngine.UI;

public class stock_data : MonoBehaviour
{
   //handles data for all the stock also updates ui according to data

    [SerializeField] string _name;
    [SerializeField] string _price;
    [SerializeField] string _multiplier;
    public int _holdings;
    [SerializeField] string _details;
    Text[] _child_text;
    [SerializeField] Text _details_text; //holds object text for details tab

    [SerializeField] AddRemove_stocks _addremove_stocks;

    private void Start()
    {
        _child_text = GetComponentsInChildren<Text>();
        assign();
    }

    public void on_stock_select()
    {
        _details_text.text = _details;
        _addremove_stocks._current_stock = this;
    }

    void assign() //fill up the repective fields with given data
    {
        _child_text[0].text = _name;
        _child_text[1].text = _price;
        _child_text[2].text = _multiplier;
        _child_text[3].text = _holdings.ToString();
        _details_text.text = _details;
    }
}
