// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/PlayerActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerActions : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public @PlayerActions()
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
                    ""processors"": ""StickDeadzone(min=0.2)"",
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
                },
                {
                    ""name"": ""ResetSpells"",
                    ""type"": ""Button"",
                    ""id"": ""8ad32072-3ddd-45fb-952f-4e09c86c8009"",
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
                    ""processors"": ""StickDeadzone"",
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
                    ""interactions"": ""Press(behavior=2)"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""879366ec-f355-40e6-9a37-01c20a5d5f46"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""ResetSpells"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Deceived_PM"",
            ""id"": ""fb8c52ed-ac40-4290-85df-62274db45a1f"",
            ""actions"": [
                {
                    ""name"": ""DivineLight"",
                    ""type"": ""Button"",
                    ""id"": ""22577e54-0704-4f30-9151-f800fae87f80"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c4700e20-ce0f-42f9-94ee-429951b47081"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""DivineLight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""3817bafa-97de-4cca-a8ea-c9e97036bfdc"",
            ""actions"": [
                {
                    ""name"": ""Navigate"",
                    ""type"": ""Button"",
                    ""id"": ""3b69c89c-88bc-4639-9a67-e70869577b7e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ezfaz"",
                    ""type"": ""Button"",
                    ""id"": ""8fdee150-3110-4664-901c-d91e3f5c70a2"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""20de7ffe-5e68-4577-ab45-cd85fd074780"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f883d995-88b8-475f-bc12-927983062562"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ezfaz"",
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
        m_Deceived_ResetSpells = m_Deceived.FindAction("ResetSpells", throwIfNotFound: true);
        // Deceived_PM
        m_Deceived_PM = asset.FindActionMap("Deceived_PM", throwIfNotFound: true);
        m_Deceived_PM_DivineLight = m_Deceived_PM.FindAction("DivineLight", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Navigate = m_UI.FindAction("Navigate", throwIfNotFound: true);
        m_UI_ezfaz = m_UI.FindAction("ezfaz", throwIfNotFound: true);
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
    private readonly InputAction m_Deceived_ResetSpells;
    public struct DeceivedActions
    {
        private @PlayerActions m_Wrapper;
        public DeceivedActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Walk => m_Wrapper.m_Deceived_Walk;
        public InputAction @Attack => m_Wrapper.m_Deceived_Attack;
        public InputAction @Run => m_Wrapper.m_Deceived_Run;
        public InputAction @Shoot => m_Wrapper.m_Deceived_Shoot;
        public InputAction @ForceField => m_Wrapper.m_Deceived_ForceField;
        public InputAction @ResetSpells => m_Wrapper.m_Deceived_ResetSpells;
        public InputActionMap Get() { return m_Wrapper.m_Deceived; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DeceivedActions set) { return set.Get(); }
        public void SetCallbacks(IDeceivedActions instance)
        {
            if (m_Wrapper.m_DeceivedActionsCallbackInterface != null)
            {
                @Walk.started -= m_Wrapper.m_DeceivedActionsCallbackInterface.OnWalk;
                @Walk.performed -= m_Wrapper.m_DeceivedActionsCallbackInterface.OnWalk;
                @Walk.canceled -= m_Wrapper.m_DeceivedActionsCallbackInterface.OnWalk;
                @Attack.started -= m_Wrapper.m_DeceivedActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_DeceivedActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_DeceivedActionsCallbackInterface.OnAttack;
                @Run.started -= m_Wrapper.m_DeceivedActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_DeceivedActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_DeceivedActionsCallbackInterface.OnRun;
                @Shoot.started -= m_Wrapper.m_DeceivedActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_DeceivedActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_DeceivedActionsCallbackInterface.OnShoot;
                @ForceField.started -= m_Wrapper.m_DeceivedActionsCallbackInterface.OnForceField;
                @ForceField.performed -= m_Wrapper.m_DeceivedActionsCallbackInterface.OnForceField;
                @ForceField.canceled -= m_Wrapper.m_DeceivedActionsCallbackInterface.OnForceField;
                @ResetSpells.started -= m_Wrapper.m_DeceivedActionsCallbackInterface.OnResetSpells;
                @ResetSpells.performed -= m_Wrapper.m_DeceivedActionsCallbackInterface.OnResetSpells;
                @ResetSpells.canceled -= m_Wrapper.m_DeceivedActionsCallbackInterface.OnResetSpells;
            }
            m_Wrapper.m_DeceivedActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Walk.started += instance.OnWalk;
                @Walk.performed += instance.OnWalk;
                @Walk.canceled += instance.OnWalk;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @ForceField.started += instance.OnForceField;
                @ForceField.performed += instance.OnForceField;
                @ForceField.canceled += instance.OnForceField;
                @ResetSpells.started += instance.OnResetSpells;
                @ResetSpells.performed += instance.OnResetSpells;
                @ResetSpells.canceled += instance.OnResetSpells;
            }
        }
    }
    public DeceivedActions @Deceived => new DeceivedActions(this);

    // Deceived_PM
    private readonly InputActionMap m_Deceived_PM;
    private IDeceived_PMActions m_Deceived_PMActionsCallbackInterface;
    private readonly InputAction m_Deceived_PM_DivineLight;
    public struct Deceived_PMActions
    {
        private @PlayerActions m_Wrapper;
        public Deceived_PMActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @DivineLight => m_Wrapper.m_Deceived_PM_DivineLight;
        public InputActionMap Get() { return m_Wrapper.m_Deceived_PM; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Deceived_PMActions set) { return set.Get(); }
        public void SetCallbacks(IDeceived_PMActions instance)
        {
            if (m_Wrapper.m_Deceived_PMActionsCallbackInterface != null)
            {
                @DivineLight.started -= m_Wrapper.m_Deceived_PMActionsCallbackInterface.OnDivineLight;
                @DivineLight.performed -= m_Wrapper.m_Deceived_PMActionsCallbackInterface.OnDivineLight;
                @DivineLight.canceled -= m_Wrapper.m_Deceived_PMActionsCallbackInterface.OnDivineLight;
            }
            m_Wrapper.m_Deceived_PMActionsCallbackInterface = instance;
            if (instance != null)
            {
                @DivineLight.started += instance.OnDivineLight;
                @DivineLight.performed += instance.OnDivineLight;
                @DivineLight.canceled += instance.OnDivineLight;
            }
        }
    }
    public Deceived_PMActions @Deceived_PM => new Deceived_PMActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_Navigate;
    private readonly InputAction m_UI_ezfaz;
    public struct UIActions
    {
        private @PlayerActions m_Wrapper;
        public UIActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Navigate => m_Wrapper.m_UI_Navigate;
        public InputAction @ezfaz => m_Wrapper.m_UI_ezfaz;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @Navigate.started -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                @Navigate.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                @Navigate.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                @ezfaz.started -= m_Wrapper.m_UIActionsCallbackInterface.OnEzfaz;
                @ezfaz.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnEzfaz;
                @ezfaz.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnEzfaz;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Navigate.started += instance.OnNavigate;
                @Navigate.performed += instance.OnNavigate;
                @Navigate.canceled += instance.OnNavigate;
                @ezfaz.started += instance.OnEzfaz;
                @ezfaz.performed += instance.OnEzfaz;
                @ezfaz.canceled += instance.OnEzfaz;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
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
        void OnResetSpells(InputAction.CallbackContext context);
    }
    public interface IDeceived_PMActions
    {
        void OnDivineLight(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnNavigate(InputAction.CallbackContext context);
        void OnEzfaz(InputAction.CallbackContext context);
    }
}
