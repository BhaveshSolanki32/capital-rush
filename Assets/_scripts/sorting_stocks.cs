using UnityEngine;

public class sorting_stocks : MonoBehaviour
{
    stock_data[] _stock_data;
    private void Start()
    {
        _stock_data = GetComponentsInChildren<stock_data>();
        sort_stocks_all();
    }

    void sort_stocks_all()
    {
        int len = _stock_data.Length;
        for(int i = 0; i <= len; i++)
        {
            for(int j = i; j <= len; j++)
            {
                if (_stock_data[j]._holdings > _stock_data[j + 1]._holdings)
                {
                    GameObject temp = transform.GetChild(j).gameObject;
                    transform.GetChild(j).gameObject = transform.GetChild(j+1).gameObject;


                }
            }
        }
    }

}
