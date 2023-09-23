using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UIElements;

public class MainScreen : MonoBehaviour
{
    private const string BEFORE_TO_TOP = "before-top-top";
    private const string TOP_TO_MIDDLE = "top-middle";
    private const string MIDDLE_TO_BOTTOM = "middle-bottom";
    private const string BOTTOM_TO_OUT = "after-bottom-bottom";

    private UIDocument _uiDocument;
    private Toggle _beforeTopToggle;
    private Toggle _topToggle;
    private Toggle _middleToggle;
    private Toggle _bottomToggle;

    void Start()
    {
        _uiDocument = GetComponent<UIDocument>();    

        _beforeTopToggle = _uiDocument.rootVisualElement.Q<Toggle>("before-top-text");
        _topToggle = _uiDocument.rootVisualElement.Q<Toggle>("top-text");
        _middleToggle = _uiDocument.rootVisualElement.Q<Toggle>("middle-text");
        _bottomToggle = _uiDocument.rootVisualElement.Q<Toggle>("bottom-text");
        Button teste = _uiDocument.rootVisualElement.Q<Button>("teste");
        _middleToggle.RegisterValueChangedCallback(CheckMiddleToggle);
    }

    void CheckMiddleToggle(ChangeEvent<bool> callback)
    {
        _beforeTopToggle.AddToClassList(BEFORE_TO_TOP);
        _topToggle.AddToClassList(TOP_TO_MIDDLE);
        _middleToggle.AddToClassList(MIDDLE_TO_BOTTOM);
        _bottomToggle.AddToClassList(BOTTOM_TO_OUT);

        _beforeTopToggle.RegisterCallback<TransitionEndEvent>(FinishTransition);
    }

    void FinishTransition(TransitionEndEvent callback)
    {
        _beforeTopToggle.RemoveFromClassList(BEFORE_TO_TOP);
        _topToggle.RemoveFromClassList(TOP_TO_MIDDLE);
        _middleToggle.RemoveFromClassList(MIDDLE_TO_BOTTOM);
        _bottomToggle.RemoveFromClassList(BOTTOM_TO_OUT);
    }
}
