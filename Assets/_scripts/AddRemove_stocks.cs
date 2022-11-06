using UnityEngine;
using UnityEngine.UI;

public class AddRemove_stocks : MonoBehaviour
{
    //upadates holding data and ui

    public stock_data _current_stock;
    
    public void add_stock()
    {
        _current_stock._holdings += 1;
        _current_stock.gameObject.GetComponentsInChildren<Text>()[3].text = _current_stock._holdings.ToString();
    }

    public void remove_stock()
    {
        if(_current_stock._holdings>0)
             _current_stock._holdings -= 1;

        _current_stock.gameObject.GetComponentsInChildren<Text>()[3].text = _current_stock._holdings.ToString();
    }
}
