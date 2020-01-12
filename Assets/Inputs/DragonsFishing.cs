// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/DragonsFishing.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @DragonsFishing : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public @DragonsFishing()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""DragonsFishing"",
    ""maps"": [
        {
            ""name"": ""Dragons"",
            ""id"": ""de446d0f-a1fd-4f0c-a0c7-e802aac6d4aa"",
            ""actions"": [
                {
                    ""name"": ""Action"",
                    ""type"": ""Button"",
                    ""id"": ""d6a0467b-ee0e-4ef6-9f95-1ef98175f82a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""B"",
                    ""type"": ""Button"",
                    ""id"": ""d7584bba-c8cb-42eb-b04a-2ab1f71b14d6"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""A"",
                    ""type"": ""Button"",
                    ""id"": ""0713c12f-e4ba-4756-8c4c-a5e8fce0669d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""X"",
                    ""type"": ""Button"",
                    ""id"": ""e5c9585d-7254-4a57-a3ab-efac909f915b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Y"",
                    ""type"": ""Button"",
                    ""id"": ""cca9c8ea-e740-4c8f-b6e5-fff0341b6bc9"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""457181a4-2b39-484d-8d65-e148868553e6"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""47673e7e-bd42-46af-b182-af60251c1355"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""c69744a9-e1e8-4f16-bd75-6be34510334d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""6cba6d60-b62c-4774-8067-1a65e05003dd"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fish"",
                    ""type"": ""Button"",
                    ""id"": ""420a3ab9-e2cf-4f0e-ada4-42b1aca38cf2"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Value"",
                    ""id"": ""368a64ac-dc5f-4c67-a25e-0a610d51bcb0"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e75e2d31-a42c-4f4b-a5d3-5ebfe14ae1b3"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3573ee2e-7f0a-4c2b-8f8c-439ad0e211f9"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""B"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5d8bf4dc-a477-4f17-a5b9-97a84abef984"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""A"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""892a6735-7e11-4c85-ab2f-ff9d91b1625d"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""X"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6bceaf58-310b-4dd1-b8d1-555430f62217"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Y"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""842cc676-3f29-4b12-a833-97be3c0abc07"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ebf97787-e283-48cc-a24b-f6795d88ea57"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dc9feb69-5cc5-4a1c-8855-8d1a6637705a"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""debe32eb-6251-4a50-8316-7fbd3253a958"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e83d73be-4562-40a0-ba5f-a6c2099519a9"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b260e73f-59fb-4ac5-99c3-21ce16721c8e"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ab832fba-b800-4359-9252-8c45293a7303"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""156d9867-070d-4f58-afc8-9202dcd60a04"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""988754e9-92ac-4323-9dea-b1ddbbc8dcb4"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fish"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""39d3c25f-f9ea-4f77-857a-f887bbb227a1"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""AxisDeadzone(min=0.4)"",
                    ""groups"": """",
                    ""action"": ""Aim"",
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
        // Dragons
        m_Dragons = asset.FindActionMap("Dragons", throwIfNotFound: true);
        m_Dragons_Action = m_Dragons.FindAction("Action", throwIfNotFound: true);
        m_Dragons_B = m_Dragons.FindAction("B", throwIfNotFound: true);
        m_Dragons_A = m_Dragons.FindAction("A", throwIfNotFound: true);
        m_Dragons_X = m_Dragons.FindAction("X", throwIfNotFound: true);
        m_Dragons_Y = m_Dragons.FindAction("Y", throwIfNotFound: true);
        m_Dragons_Up = m_Dragons.FindAction("Up", throwIfNotFound: true);
        m_Dragons_Down = m_Dragons.FindAction("Down", throwIfNotFound: true);
        m_Dragons_Left = m_Dragons.FindAction("Left", throwIfNotFound: true);
        m_Dragons_Right = m_Dragons.FindAction("Right", throwIfNotFound: true);
        m_Dragons_Fish = m_Dragons.FindAction("Fish", throwIfNotFound: true);
        m_Dragons_Aim = m_Dragons.FindAction("Aim", throwIfNotFound: true);
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

    // Dragons
    private readonly InputActionMap m_Dragons;
    private IDragonsActions m_DragonsActionsCallbackInterface;
    private readonly InputAction m_Dragons_Action;
    private readonly InputAction m_Dragons_B;
    private readonly InputAction m_Dragons_A;
    private readonly InputAction m_Dragons_X;
    private readonly InputAction m_Dragons_Y;
    private readonly InputAction m_Dragons_Up;
    private readonly InputAction m_Dragons_Down;
    private readonly InputAction m_Dragons_Left;
    private readonly InputAction m_Dragons_Right;
    private readonly InputAction m_Dragons_Fish;
    private readonly InputAction m_Dragons_Aim;
    public struct DragonsActions
    {
        private @DragonsFishing m_Wrapper;
        public DragonsActions(@DragonsFishing wrapper) { m_Wrapper = wrapper; }
        public InputAction @Action => m_Wrapper.m_Dragons_Action;
        public InputAction @B => m_Wrapper.m_Dragons_B;
        public InputAction @A => m_Wrapper.m_Dragons_A;
        public InputAction @X => m_Wrapper.m_Dragons_X;
        public InputAction @Y => m_Wrapper.m_Dragons_Y;
        public InputAction @Up => m_Wrapper.m_Dragons_Up;
        public InputAction @Down => m_Wrapper.m_Dragons_Down;
        public InputAction @Left => m_Wrapper.m_Dragons_Left;
        public InputAction @Right => m_Wrapper.m_Dragons_Right;
        public InputAction @Fish => m_Wrapper.m_Dragons_Fish;
        public InputAction @Aim => m_Wrapper.m_Dragons_Aim;
        public InputActionMap Get() { return m_Wrapper.m_Dragons; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DragonsActions set) { return set.Get(); }
        public void SetCallbacks(IDragonsActions instance)
        {
            if (m_Wrapper.m_DragonsActionsCallbackInterface != null)
            {
                @Action.started -= m_Wrapper.m_DragonsActionsCallbackInterface.OnAction;
                @Action.performed -= m_Wrapper.m_DragonsActionsCallbackInterface.OnAction;
                @Action.canceled -= m_Wrapper.m_DragonsActionsCallbackInterface.OnAction;
                @B.started -= m_Wrapper.m_DragonsActionsCallbackInterface.OnB;
                @B.performed -= m_Wrapper.m_DragonsActionsCallbackInterface.OnB;
                @B.canceled -= m_Wrapper.m_DragonsActionsCallbackInterface.OnB;
                @A.started -= m_Wrapper.m_DragonsActionsCallbackInterface.OnA;
                @A.performed -= m_Wrapper.m_DragonsActionsCallbackInterface.OnA;
                @A.canceled -= m_Wrapper.m_DragonsActionsCallbackInterface.OnA;
                @X.started -= m_Wrapper.m_DragonsActionsCallbackInterface.OnX;
                @X.performed -= m_Wrapper.m_DragonsActionsCallbackInterface.OnX;
                @X.canceled -= m_Wrapper.m_DragonsActionsCallbackInterface.OnX;
                @Y.started -= m_Wrapper.m_DragonsActionsCallbackInterface.OnY;
                @Y.performed -= m_Wrapper.m_DragonsActionsCallbackInterface.OnY;
                @Y.canceled -= m_Wrapper.m_DragonsActionsCallbackInterface.OnY;
                @Up.started -= m_Wrapper.m_DragonsActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_DragonsActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_DragonsActionsCallbackInterface.OnUp;
                @Down.started -= m_Wrapper.m_DragonsActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_DragonsActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_DragonsActionsCallbackInterface.OnDown;
                @Left.started -= m_Wrapper.m_DragonsActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_DragonsActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_DragonsActionsCallbackInterface.OnLeft;
                @Right.started -= m_Wrapper.m_DragonsActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_DragonsActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_DragonsActionsCallbackInterface.OnRight;
                @Fish.started -= m_Wrapper.m_DragonsActionsCallbackInterface.OnFish;
                @Fish.performed -= m_Wrapper.m_DragonsActionsCallbackInterface.OnFish;
                @Fish.canceled -= m_Wrapper.m_DragonsActionsCallbackInterface.OnFish;
                @Aim.started -= m_Wrapper.m_DragonsActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_DragonsActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_DragonsActionsCallbackInterface.OnAim;
            }
            m_Wrapper.m_DragonsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Action.started += instance.OnAction;
                @Action.performed += instance.OnAction;
                @Action.canceled += instance.OnAction;
                @B.started += instance.OnB;
                @B.performed += instance.OnB;
                @B.canceled += instance.OnB;
                @A.started += instance.OnA;
                @A.performed += instance.OnA;
                @A.canceled += instance.OnA;
                @X.started += instance.OnX;
                @X.performed += instance.OnX;
                @X.canceled += instance.OnX;
                @Y.started += instance.OnY;
                @Y.performed += instance.OnY;
                @Y.canceled += instance.OnY;
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
                @Fish.started += instance.OnFish;
                @Fish.performed += instance.OnFish;
                @Fish.canceled += instance.OnFish;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
            }
        }
    }
    public DragonsActions @Dragons => new DragonsActions(this);
    private int m_XboxSchemeIndex = -1;
    public InputControlScheme XboxScheme
    {
        get
        {
            if (m_XboxSchemeIndex == -1) m_XboxSchemeIndex = asset.FindControlSchemeIndex("Xbox");
            return asset.controlSchemes[m_XboxSchemeIndex];
        }
    }
    public interface IDragonsActions
    {
        void OnAction(InputAction.CallbackContext context);
        void OnB(InputAction.CallbackContext context);
        void OnA(InputAction.CallbackContext context);
        void OnX(InputAction.CallbackContext context);
        void OnY(InputAction.CallbackContext context);
        void OnUp(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnFish(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
    }
}
