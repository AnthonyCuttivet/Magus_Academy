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
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""4856e352-6856-43c5-bdcf-9d8abf723af2"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""d2d6dbdf-7e0a-41c9-8c7a-43296e42a235"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""20c919b6-3a19-474c-bad2-a94524a002ab"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ForceField"",
                    ""type"": ""Button"",
                    ""id"": ""0efc5635-4d45-4c0f-83d6-e958e6f46a9b"",
                    ""expectedControlType"": """",
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
                    ""processors"": ""StickDeadzone(max=0.1)"",
                    ""groups"": ""Xbox"",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""565c60a2-a8d4-42b6-939e-18e80594c8ea"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""03bef1d8-1998-42b0-89dc-4e4c19f99867"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": ""Press(pressPoint=0.1,behavior=2)"",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6ce79dec-2a23-4ce7-a1a4-f01b972efac8"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a9f2e678-5f29-49e5-b4af-2577c6d547d6"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""ForceField"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Xbox"",
            ""bindingGroup"": ""Xbox"",
            ""devices"": [
                {
                    ""devicePath"": ""<XInputController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Deceived
        m_Deceived = asset.FindActionMap("Deceived", throwIfNotFound: true);
        m_Deceived_Walk = m_Deceived.FindAction("Walk", throwIfNotFound: true);
        m_Deceived_Attack = m_Deceived.FindAction("Attack", throwIfNotFound: true);
        m_Deceived_Run = m_Deceived.FindAction("Run", throwIfNotFound: true);
        m_Deceived_Shoot = m_Deceived.FindAction("Shoot", throwIfNotFound: true);
        m_Deceived_ForceField = m_Deceived.FindAction("ForceField", throwIfNotFound: true);
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
    private readonly InputAction m_Deceived_Attack;
    private readonly InputAction m_Deceived_Run;
    private readonly InputAction m_Deceived_Shoot;
    private readonly InputAction m_Deceived_ForceField;
    public struct DeceivedActions
    {
        private PlayerActions m_Wrapper;
        public DeceivedActions(PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Walk => m_Wrapper.m_Deceived_Walk;
        public InputAction @Attack => m_Wrapper.m_Deceived_Attack;
        public InputAction @Run => m_Wrapper.m_Deceived_Run;
        public InputAction @Shoot => m_Wrapper.m_Deceived_Shoot;
        public InputAction @ForceField => m_Wrapper.m_Deceived_ForceField;
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
                Attack.started -= m_Wrapper.m_DeceivedActionsCallbackInterface.OnAttack;
                Attack.performed -= m_Wrapper.m_DeceivedActionsCallbackInterface.OnAttack;
                Attack.canceled -= m_Wrapper.m_DeceivedActionsCallbackInterface.OnAttack;
                Run.started -= m_Wrapper.m_DeceivedActionsCallbackInterface.OnRun;
                Run.performed -= m_Wrapper.m_DeceivedActionsCallbackInterface.OnRun;
                Run.canceled -= m_Wrapper.m_DeceivedActionsCallbackInterface.OnRun;
                Shoot.started -= m_Wrapper.m_DeceivedActionsCallbackInterface.OnShoot;
                Shoot.performed -= m_Wrapper.m_DeceivedActionsCallbackInterface.OnShoot;
                Shoot.canceled -= m_Wrapper.m_DeceivedActionsCallbackInterface.OnShoot;
                ForceField.started -= m_Wrapper.m_DeceivedActionsCallbackInterface.OnForceField;
                ForceField.performed -= m_Wrapper.m_DeceivedActionsCallbackInterface.OnForceField;
                ForceField.canceled -= m_Wrapper.m_DeceivedActionsCallbackInterface.OnForceField;
            }
            m_Wrapper.m_DeceivedActionsCallbackInterface = instance;
            if (instance != null)
            {
                Walk.started += instance.OnWalk;
                Walk.performed += instance.OnWalk;
                Walk.canceled += instance.OnWalk;
                Attack.started += instance.OnAttack;
                Attack.performed += instance.OnAttack;
                Attack.canceled += instance.OnAttack;
                Run.started += instance.OnRun;
                Run.performed += instance.OnRun;
                Run.canceled += instance.OnRun;
                Shoot.started += instance.OnShoot;
                Shoot.performed += instance.OnShoot;
                Shoot.canceled += instance.OnShoot;
                ForceField.started += instance.OnForceField;
                ForceField.performed += instance.OnForceField;
                ForceField.canceled += instance.OnForceField;
            }
        }
    }
    public DeceivedActions @Deceived => new DeceivedActions(this);
    private int m_XboxSchemeIndex = -1;
    public InputControlScheme XboxScheme
    {
        get
        {
            if (m_XboxSchemeIndex == -1) m_XboxSchemeIndex = asset.FindControlSchemeIndex("Xbox");
            return asset.controlSchemes[m_XboxSchemeIndex];
        }
    }
    public interface IDeceivedActions
    {
        void OnWalk(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnForceField(InputAction.CallbackContext context);
    }
}
