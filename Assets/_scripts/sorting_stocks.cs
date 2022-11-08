using System.Collections;
using UnityEngine;

public class sorting_stocks : MonoBehaviour
{
    //handles sorting of element according to their holdings
    [SerializeField] GameObject _place_holder;


    private void Start()
    {
        sort_stocks_all();
    }

    void sort_stocks_all() //does initial sorting of all the stocks in ascending order
    {
        int len = transform.childCount;
        for (int i = 0; i < len; i++)
        {
            int largest_num_index = i;
            for (int j = i + 1; j < len; j++)
            {
                if (transform.GetChild(largest_num_index).GetComponent<stock_data>()._holdings < transform.GetChild(j).GetComponent<stock_data>()._holdings)
                {
                    largest_num_index = j;
                }
            }
            transform.GetChild(largest_num_index).SetSiblingIndex(i);
        }
        transform.GetChild(0).GetComponent<stock_data>().on_stock_select(); // selects the first element
    }

    public void onAddRemove_holdings(GameObject _target, int _AddOrRemove)
    {
        int _current_index, _index_to_check;

        _current_index = _target.transform.GetSiblingIndex();
        _index_to_check = _current_index - _AddOrRemove;
        print(transform.GetChild(_index_to_check).GetComponent<stock_data>()._holdings * _AddOrRemove < _target.GetComponent<stock_data>()._holdings * _AddOrRemove);
        //
        while (_index_to_check > 0 && _index_to_check < transform.childCount && transform.GetChild(_index_to_check).GetComponent<stock_data>()._holdings * _AddOrRemove < _target.GetComponent<stock_data>()._holdings * _AddOrRemove)
        {
            print("in");
            _index_to_check -= _AddOrRemove;
        }

        
        if (_current_index - _AddOrRemove != _index_to_check)
        {
            print("out");
            _place_holder.SetActive(true);
            _place_holder.transform.SetParent(transform);
            _place_holder.transform.SetSiblingIndex((_AddOrRemove == 1) ? (_index_to_check+1) : (_index_to_check));
            _target.transform.SetParent(transform.parent.parent);
            StartCoroutine(moveTowards(_target));
        }

    }


    //public void OnAdd_holdings(GameObject changed_target)
    //{

    //    if (_place_holder.transform.parent != transform)
    //    {
    //        _place_holder.transform.SetParent(transform);
    //        _place_holder.transform.SetSiblingIndex(changed_target.transform.GetSiblingIndex());
    //    }

    //    int above_values = _place_holder.transform.GetSiblingIndex() - 1;
    //    while (above_values >= 0 && changed_target.GetComponent<stock_data>()._holdings > transform.GetChild(above_values).GetComponent<stock_data>()._holdings)
    //    {
    //        above_values -= 1;
    //    }

    //    if (above_values + 1 != _place_holder.transform.GetSiblingIndex())
    //    {
    //        print("add");
    //        _place_holder.transform.SetSiblingIndex(above_values + 1);
    //        _place_holder.SetActive(true);

    //        changed_target.transform.SetParent(transform.parent.parent);
    //        StartCoroutine(moveTowards(changed_target));
    //    }
    //}

    //public void OnRemove_holdings(GameObject changed_target)
    //{
    //    if (_place_holder.transform.parent != transform)
    //    {
    //        _place_holder.transform.SetParent(transform);
    //        _place_holder.transform.SetSiblingIndex(changed_target.transform.GetSiblingIndex() + 1);
    //    }
    //    int above_values = _place_holder.transform.GetSiblingIndex() + 1;
    //    while (above_values < transform.childCount && changed_target.GetComponent<stock_data>()._holdings < transform.GetChild(above_values).GetComponent<stock_data>()._holdings)
    //    {
    //        above_values += 1;
    //    }
    //    if (above_values != _place_holder.transform.GetSiblingIndex())
    //    {
    //        print("in");
    //        _place_holder.transform.SetSiblingIndex(above_values);
    //        _place_holder.SetActive(true);

    //        changed_target.transform.SetParent(transform.parent.parent);
    //        StartCoroutine(moveTowards(changed_target));
    //    }


    //}

    IEnumerator moveTowards(GameObject target)//target holds the gameobject that needs to be moved,,target_post holds postion where it need to go
    {
        while ((int)target.transform.position.y/10 != (int)_place_holder.transform.position.y/10)
        {
            print(target.transform.position.y - _place_holder.transform.position.y);
            target.transform.position = Vector3.Lerp(target.transform.position, _place_holder.transform.position, 0.1f);
            yield return new WaitForSeconds(0.02f);
        }

        print("doe");
        _place_holder.SetActive(false);
        target.transform.SetParent(transform);
        target.transform.SetSiblingIndex(_place_holder.transform.GetSiblingIndex());
        _place_holder.transform.SetParent(this.transform.parent.parent);
        print("set");
        StopCoroutine("moveTowards");
        yield return null;
    }


}
