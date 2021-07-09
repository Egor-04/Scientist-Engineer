using UnityEngine;

public class Holder : MonoBehaviour
{
    [Header("Ray Length")]
    [SerializeField] private float _rayLength;

    [Header("Holder Point")]
    [SerializeField] private Transform _holderPoint;

    [Header("Holder Object Prefab")]
    [SerializeField] private GameObject _holderPrefab;

    [Header("Buttons")]
    [SerializeField] private KeyCode _holdButton = KeyCode.Mouse0;

    private GameObject _currentHolderPrefab;

    private void Start()
    {

    }

    private void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * _rayLength, Color.red);

        InstantiateHolder();
    }

    private void InstantiateHolder()
    {
        if (Input.GetKeyDown(_holdButton))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, _rayLength))
            {
                if (hit.collider)
                {
                    if (hit.collider.GetComponent<Rigidbody>())
                    {
                        Vector3 holderPoint = hit.point;
                        GameObject draggedObject = hit.collider.gameObject;

                        GameObject instantiatedHolderPrefab = Instantiate(_holderPrefab, holderPoint, Quaternion.identity);
                        _currentHolderPrefab = instantiatedHolderPrefab;

                        CharacterJoint characterJoint = instantiatedHolderPrefab.GetComponent<CharacterJoint>();
                        characterJoint.connectedBody = draggedObject.GetComponent<Rigidbody>();
                    }
                }
            }
        }
        else if (Input.GetKey(_holdButton))
        {
            DragObject();
        }
        else if (Input.GetKeyUp(_holdButton))
        {
            Destroy(_currentHolderPrefab);
        }
    }

    private void DragObject()
    {
        if (_currentHolderPrefab)
        {
            _currentHolderPrefab.transform.position = _holderPoint.position;
            Debug.Log("I Dragged Object");
        }
    }
}
