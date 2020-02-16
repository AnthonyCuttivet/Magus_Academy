// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/CharacterSelection.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @CharacterSelection : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public @CharacterSelection()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""CharacterSelection"",
    ""maps"": [
        {
            ""name"": ""TipsScreen"",
            ""id"": ""f7a70b1c-31e1-4d34-94fc-562fc3d5b52b"",
            ""actions"": [
                {
                    ""name"": ""Ready"",
                    ""type"": ""Button"",
                    ""id"": ""18d1192a-8fac-4906-9911-53ad7054ade3"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Validate"",
                    ""type"": ""Button"",
                    ""id"": ""15216a05-2511-42e9-9999-bcd7e2cae44d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""02945c5d-6b8e-4ee9-882b-26687e02688d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""bee17ff0-51c9-44ab-9289-8975b4cb3af3"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ToggleDance"",
                    ""type"": ""Button"",
                    ""id"": ""263957c0-7e32-4f7a-ac43-4764471fee5f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8dc30274-c2b9-4140-bb50-e2c829cf8630"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ready"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""279124ec-849e-4ae5-bed6-672893a88446"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Validate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""69d36658-b7a1-4ad7-aa92-9609229aa162"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fb86c816-da61-45d1-86e7-f642dab02283"",
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
                    ""id"": ""27b29aef-3f44-4c2f-ae89-d80aaac5a94c"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleDance"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""xbox"",
            ""bindingGroup"": ""xbox"",
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
        // TipsScreen
        m_TipsScreen = asset.FindActionMap("TipsScreen", throwIfNotFound: true);
        m_TipsScreen_Ready = m_TipsScreen.FindAction("Ready", throwIfNotFound: true);
        m_TipsScreen_Validate = m_TipsScreen.FindAction("Validate", throwIfNotFound: true);
        m_TipsScreen_Back = m_TipsScreen.FindAction("Back", throwIfNotFound: true);
        m_TipsScreen_Move = m_TipsScreen.FindAction("Move", throwIfNotFound: true);
        m_TipsScreen_ToggleDance = m_TipsScreen.FindAction("ToggleDance", throwIfNotFound: true);
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

    // TipsScreen
    private readonly InputActionMap m_TipsScreen;
    private ITipsScreenActions m_TipsScreenActionsCallbackInterface;
    private readonly InputAction m_TipsScreen_Ready;
    private readonly InputAction m_TipsScreen_Validate;
    private readonly InputAction m_TipsScreen_Back;
    private readonly InputAction m_TipsScreen_Move;
    private readonly InputAction m_TipsScreen_ToggleDance;
    public struct TipsScreenActions
    {
        private @CharacterSelection m_Wrapper;
        public TipsScreenActions(@CharacterSelection wrapper) { m_Wrapper = wrapper; }
        public InputAction @Ready => m_Wrapper.m_TipsScreen_Ready;
        public InputAction @Validate => m_Wrapper.m_TipsScreen_Validate;
        public InputAction @Back => m_Wrapper.m_TipsScreen_Back;
        public InputAction @Move => m_Wrapper.m_TipsScreen_Move;
        public InputAction @ToggleDance => m_Wrapper.m_TipsScreen_ToggleDance;
        public InputActionMap Get() { return m_Wrapper.m_TipsScreen; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TipsScreenActions set) { return set.Get(); }
        public void SetCallbacks(ITipsScreenActions instance)
        {
            if (m_Wrapper.m_TipsScreenActionsCallbackInterface != null)
            {
                @Ready.started -= m_Wrapper.m_TipsScreenActionsCallbackInterface.OnReady;
                @Ready.performed -= m_Wrapper.m_TipsScreenActionsCallbackInterface.OnReady;
                @Ready.canceled -= m_Wrapper.m_TipsScreenActionsCallbackInterface.OnReady;
                @Validate.started -= m_Wrapper.m_TipsScreenActionsCallbackInterface.OnValidate;
                @Validate.performed -= m_Wrapper.m_TipsScreenActionsCallbackInterface.OnValidate;
                @Validate.canceled -= m_Wrapper.m_TipsScreenActionsCallbackInterface.OnValidate;
                @Back.started -= m_Wrapper.m_TipsScreenActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_TipsScreenActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_TipsScreenActionsCallbackInterface.OnBack;
                @Move.started -= m_Wrapper.m_TipsScreenActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_TipsScreenActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_TipsScreenActionsCallbackInterface.OnMove;
                @ToggleDance.started -= m_Wrapper.m_TipsScreenActionsCallbackInterface.OnToggleDance;
                @ToggleDance.performed -= m_Wrapper.m_TipsScreenActionsCallbackInterface.OnToggleDance;
                @ToggleDance.canceled -= m_Wrapper.m_TipsScreenActionsCallbackInterface.OnToggleDance;
            }
            m_Wrapper.m_TipsScreenActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Ready.started += instance.OnReady;
                @Ready.performed += instance.OnReady;
                @Ready.canceled += instance.OnReady;
                @Validate.started += instance.OnValidate;
                @Validate.performed += instance.OnValidate;
                @Validate.canceled += instance.OnValidate;
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @ToggleDance.started += instance.OnToggleDance;
                @ToggleDance.performed += instance.OnToggleDance;
                @ToggleDance.canceled += instance.OnToggleDance;
            }
        }
    }
    public TipsScreenActions @TipsScreen => new TipsScreenActions(this);
    private int m_xboxSchemeIndex = -1;
    public InputControlScheme xboxScheme
    {
        get
        {
            if (m_xboxSchemeIndex == -1) m_xboxSchemeIndex = asset.FindControlSchemeIndex("xbox");
            return asset.controlSchemes[m_xboxSchemeIndex];
        }
    }
    public interface ITipsScreenActions
    {
        void OnReady(InputAction.CallbackContext context);
        void OnValidate(InputAction.CallbackContext context);
        void OnBack(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnToggleDance(InputAction.CallbackContext context);
    }
}
