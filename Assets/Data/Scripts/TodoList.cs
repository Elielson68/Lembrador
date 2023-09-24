using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "TodoList", menuName = "Lembrador/TodoList", order = 0)]
public class TodoList : ScriptableObject {
    [SerializeField]
    private List<string> _itens = new(); 
    private int _prePreCurrentIndex;
    private int _preCurrentIndex;
    private int _currentIndex;
    private int _afterIndex;

    public void Init()
    {
        _prePreCurrentIndex = _itens.Count-2;
        _preCurrentIndex = _itens.Count-1;
        _currentIndex = 0;
        _afterIndex = 1;
    }

    public (string, string, string, string) GetNext()
    {
        UpdateIndex();
        return GetCurrent();
    }

    public (string, string, string, string) GetCurrent()
    {
        var nexts = (_itens[_prePreCurrentIndex], _itens[_preCurrentIndex], _itens[_currentIndex], _itens[_afterIndex]);
        return nexts;
    }

    private void UpdateIndex()
    {
        IncrementIndex(ref _prePreCurrentIndex);
        IncrementIndex(ref _preCurrentIndex);
        IncrementIndex(ref _currentIndex);
        IncrementIndex(ref _afterIndex);
        UnityEngine.Debug.LogWarning($"BeforeIndex: {_preCurrentIndex} | CurrentIndex: {_currentIndex} | AfterIndex: {_afterIndex}");
    }

    private void IncrementIndex(ref int index)
    {
        index = (index+1) % _itens.Count;
    }

}

