// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/LevelSelection.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @LevelSelection : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public @LevelSelection()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""LevelSelection"",
    ""maps"": [
        {
            ""name"": ""Pointer"",
            ""id"": ""37cbcc35-d94d-4878-a24d-5e77417b4bdf"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""caba2201-260a-415e-987a-3a3135c7ed26"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": ""StickDeadzone(min=0.05)"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Lock"",
                    ""type"": ""Button"",
                    ""id"": ""a9cc46b6-a716-4fdf-8726-53d342ebee76"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CancelLock"",
                    ""type"": ""Button"",
                    ""id"": ""a070dfde-2669-490e-9b87-2cd929ce1d67"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""027a6df7-c36b-4056-b161-dfa9a71361f4"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8b67dccf-f1b7-4b70-8172-6d533fcc00eb"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Lock"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cc8fec0d-b5b2-4f0a-9034-205704de811e"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CancelLock"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Pointer
        m_Pointer = asset.FindActionMap("Pointer", throwIfNotFound: true);
        m_Pointer_Move = m_Pointer.FindAction("Move", throwIfNotFound: true);
        m_Pointer_Lock = m_Pointer.FindAction("Lock", throwIfNotFound: true);
        m_Pointer_CancelLock = m_Pointer.FindAction("CancelLock", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Pointer
    private readonly InputActionMap m_Pointer;
    private IPointerActions m_PointerActionsCallbackInterface;
    private readonly InputAction m_Pointer_Move;
    private readonly InputAction m_Pointer_Lock;
    private readonly InputAction m_Pointer_CancelLock;
    public struct PointerActions
    {
        private @LevelSelection m_Wrapper;
        public PointerActions(@LevelSelection wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Pointer_Move;
        public InputAction @Lock => m_Wrapper.m_Pointer_Lock;
        public InputAction @CancelLock => m_Wrapper.m_Pointer_CancelLock;
        public InputActionMap Get() { return m_Wrapper.m_Pointer; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PointerActions set) { return set.Get(); }
        public void SetCallbacks(IPointerActions instance)
        {
            if (m_Wrapper.m_PointerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PointerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PointerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PointerActionsCallbackInterface.OnMove;
                @Lock.started -= m_Wrapper.m_PointerActionsCallbackInterface.OnLock;
                @Lock.performed -= m_Wrapper.m_PointerActionsCallbackInterface.OnLock;
                @Lock.canceled -= m_Wrapper.m_PointerActionsCallbackInterface.OnLock;
                @CancelLock.started -= m_Wrapper.m_PointerActionsCallbackInterface.OnCancelLock;
                @CancelLock.performed -= m_Wrapper.m_PointerActionsCallbackInterface.OnCancelLock;
                @CancelLock.canceled -= m_Wrapper.m_PointerActionsCallbackInterface.OnCancelLock;
            }
            m_Wrapper.m_PointerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Lock.started += instance.OnLock;
                @Lock.performed += instance.OnLock;
                @Lock.canceled += instance.OnLock;
                @CancelLock.started += instance.OnCancelLock;
                @CancelLock.performed += instance.OnCancelLock;
                @CancelLock.canceled += instance.OnCancelLock;
            }
        }
    }
    public PointerActions @Pointer => new PointerActions(this);
    public interface IPointerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnLock(InputAction.CallbackContext context);
        void OnCancelLock(InputAction.CallbackContext context);
    }
}
