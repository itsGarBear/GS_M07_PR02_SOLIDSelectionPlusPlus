using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CompositeSelectionResponse : MonoBehaviour, ISelectionResponse, IChangeable
{
    [SerializeField] private GameObject selectionResponseHolder;
    private List<ISelectionResponse> _selectionResponses;
    private int _currNdx;
    private Transform currSel;

    private void Start()
    {
        _selectionResponses = selectionResponseHolder.GetComponents<ISelectionResponse>().ToList();
        for (int i = 0; i < _selectionResponses.Count; i++)
            print("" + _selectionResponses[i]);
    }

    public void Next()
    {
        

        _selectionResponses[_currNdx].OnDeselect(currSel);
        _currNdx = (_currNdx + 1) % _selectionResponses.Count;
        _selectionResponses[_currNdx].OnSelect(currSel);
    }

    public void OnDeselect(Transform selection)
    {
        currSel = null;
        if(HasSelection())
            _selectionResponses[_currNdx].OnDeselect(selection);
    }

    public void OnSelect(Transform selection)
    {
        currSel = selection;
        if (HasSelection())
            _selectionResponses[_currNdx].OnSelect(selection);
    }

    private bool HasSelection()
    {
        return _currNdx > -1 && _currNdx < _selectionResponses.Count;
    }

}
