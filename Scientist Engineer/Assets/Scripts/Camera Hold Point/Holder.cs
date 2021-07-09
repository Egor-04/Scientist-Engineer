using UnityEngine;

public class Holder : MonoBehaviour
{
    [Header("Scroll Holder Point Sensitivity")]
    [SerializeField] private float _sensitivity = 10f;

    [Header("Ray Length")]
    [SerializeField] private float _rayLength;

    [Header("Holder Point")]
    [SerializeField] private Transform _holderPoint;

    [Header("Holder Object Prefab")]
    [SerializeField] private GameObject _holderPrefab;

    [Header("Buttons")]
    [SerializeField] private KeyCode _holdButton = KeyCode.Mouse0;

    private GameObject _currentHolderPrefab;
    private CharacterJoint _characterJoint;

    private void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * _rayLength, Color.red);

        if (PlayerStates.PlayerStatesScript.CanHold)
        {
            InstantiateHolder();
        }
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
                        _characterJoint = instantiatedHolderPrefab.GetComponent<CharacterJoint>();

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
            if (_characterJoint)
            {
                _characterJoint.connectedBody.velocity = new Vector3(0f, 0f, 0f);
            }

            Destroy(_currentHolderPrefab);
        }
    }

    private void DragObject()
    {
        if (_currentHolderPrefab)
        {
            _currentHolderPrefab.transform.position = _holderPoint.position;
            HolderPointScrolling();
        }
    }

    private void HolderPointScrolling()
    {
        float mouseWheelValue = Input.GetAxis("Mouse ScrollWheel");

        _holderPoint.position += _sensitivity * mouseWheelValue * Time.deltaTime * _holderPoint.localPosition.z * transform.forward;
    }
}