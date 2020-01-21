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
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""02945c5d-6b8e-4ee9-882b-26687e02688d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
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
                    ""name"": ""Skip"",
                    ""type"": ""Button"",
                    ""id"": ""55d88079-d100-4ee9-b23a-d0194c33a70c"",
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
                    ""action"": ""Cancel"",
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
                    ""id"": ""5d86e24f-f59c-40b8-9f1c-630347597a3c"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skip"",
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
        m_TipsScreen_Cancel = m_TipsScreen.FindAction("Cancel", throwIfNotFound: true);
        m_TipsScreen_Move = m_TipsScreen.FindAction("Move", throwIfNotFound: true);
        m_TipsScreen_Skip = m_TipsScreen.FindAction("Skip", throwIfNotFound: true);
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
    private readonly InputAction m_TipsScreen_Cancel;
    private readonly InputAction m_TipsScreen_Move;
    private readonly InputAction m_TipsScreen_Skip;
    public struct TipsScreenActions
    {
        private @CharacterSelection m_Wrapper;
        public TipsScreenActions(@CharacterSelection wrapper) { m_Wrapper = wrapper; }
        public InputAction @Ready => m_Wrapper.m_TipsScreen_Ready;
        public InputAction @Validate => m_Wrapper.m_TipsScreen_Validate;
        public InputAction @Cancel => m_Wrapper.m_TipsScreen_Cancel;
        public InputAction @Move => m_Wrapper.m_TipsScreen_Move;
        public InputAction @Skip => m_Wrapper.m_TipsScreen_Skip;
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
                @Cancel.started -= m_Wrapper.m_TipsScreenActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_TipsScreenActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_TipsScreenActionsCallbackInterface.OnCancel;
                @Move.started -= m_Wrapper.m_TipsScreenActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_TipsScreenActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_TipsScreenActionsCallbackInterface.OnMove;
                @Skip.started -= m_Wrapper.m_TipsScreenActionsCallbackInterface.OnSkip;
                @Skip.performed -= m_Wrapper.m_TipsScreenActionsCallbackInterface.OnSkip;
                @Skip.canceled -= m_Wrapper.m_TipsScreenActionsCallbackInterface.OnSkip;
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
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Skip.started += instance.OnSkip;
                @Skip.performed += instance.OnSkip;
                @Skip.canceled += instance.OnSkip;
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
        void OnCancel(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnSkip(InputAction.CallbackContext context);
    }
}
