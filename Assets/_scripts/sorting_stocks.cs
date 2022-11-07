using UnityEngine;

public class sorting_stocks : MonoBehaviour
{
    //handles sorting of element according to their holdings
    private void Start()
    {
        sort_stocks_all();
    }

    void sort_stocks_all() //does initial sorting of all the stocks in ascending order
    {
        int len = transform.childCount;
        for(int i = 0; i < len; i++)
        {
            int largest_num_index = i;
            for(int j = i+1; j < len; j++)
            {
                if (transform.GetChild(largest_num_index).GetComponent<stock_data>()._holdings < transform.GetChild(j).GetComponent<stock_data>()._holdings)
                {
                    largest_num_index = j;
                }
            }
            transform.GetChild(largest_num_index).SetSiblingIndex(i);
        }
    }

    public void OnAdd_holdings(GameObject changed_target)
    {
        int above_values = changed_target.transform.GetSiblingIndex() - 1;
        while (above_values >= 0 && changed_target.GetComponent<stock_data>()._holdings > transform.GetChild(above_values).GetComponent<stock_data>()._holdings)
        {
            above_values -= 1;
        }print(above_values);
        changed_target.transform.SetSiblingIndex(above_values+1);
    }

    public void OnRemove_holdings(GameObject changed_target)
    {
        int above_values = changed_target.transform.GetSiblingIndex() + 1;
        while (above_values < transform.childCount && changed_target.GetComponent<stock_data>()._holdings < transform.GetChild(above_values).GetComponent<stock_data>()._holdings && above_values < transform.childCount)
        {
            above_values += 1;
        }
        changed_target.transform.SetSiblingIndex(above_values-1);
    }

}
