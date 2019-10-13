// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/PlayerActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class PlayerActions : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public PlayerActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerActions"",
    ""maps"": [
        {
            ""name"": ""Deceived"",
            ""id"": ""8a886741-6d69-46ff-81a1-f14cd1df9986"",
            ""actions"": [
                {
                    ""name"": ""Walk"",
                    ""type"": ""Value"",
                    ""id"": ""f114cda7-0dd0-45be-a113-e87cdf6b02e4"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9eba1b44-dfd0-4c18-9681-8704c465e7ba"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Deceived
        m_Deceived = asset.FindActionMap("Deceived", throwIfNotFound: true);
        m_Deceived_Walk = m_Deceived.FindAction("Walk", throwIfNotFound: true);
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

    // Deceived
    private readonly InputActionMap m_Deceived;
    private IDeceivedActions m_DeceivedActionsCallbackInterface;
    private readonly InputAction m_Deceived_Walk;
    public struct DeceivedActions
    {
        private PlayerActions m_Wrapper;
        public DeceivedActions(PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Walk => m_Wrapper.m_Deceived_Walk;
        public InputActionMap Get() { return m_Wrapper.m_Deceived; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DeceivedActions set) { return set.Get(); }
        public void SetCallbacks(IDeceivedActions instance)
        {
            if (m_Wrapper.m_DeceivedActionsCallbackInterface != null)
            {
                Walk.started -= m_Wrapper.m_DeceivedActionsCallbackInterface.OnWalk;
                Walk.performed -= m_Wrapper.m_DeceivedActionsCallbackInterface.OnWalk;
                Walk.canceled -= m_Wrapper.m_DeceivedActionsCallbackInterface.OnWalk;
            }
            m_Wrapper.m_DeceivedActionsCallbackInterface = instance;
            if (instance != null)
            {
                Walk.started += instance.OnWalk;
                Walk.performed += instance.OnWalk;
                Walk.canceled += instance.OnWalk;
            }
        }
    }
    public DeceivedActions @Deceived => new DeceivedActions(this);
    public interface IDeceivedActions
    {
        void OnWalk(InputAction.CallbackContext context);
    }
}
