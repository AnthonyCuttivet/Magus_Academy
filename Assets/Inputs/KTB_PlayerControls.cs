// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/KTB_PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @KTB_PlayerControls : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public @KTB_PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""KTB_PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Alive"",
            ""id"": ""3192ca74-95e9-4072-863e-50f5a728ebe0"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""75fd0773-4887-46c4-8975-c14f84f37cb7"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""0bd65fed-1450-4cae-a43d-b87fb97b633f"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""1cb318c3-bbcc-4f44-869b-f540cd78092d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""84d36d97-41fd-47a9-afd3-f4b653cf26f5"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d7af27d7-6d66-4478-b55b-7d87c957b4d9"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0a250882-fd88-4457-8215-ff36b5029792"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone(min=0.5,max=1)"",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7eaf3505-62b1-40a0-84e8-cc824ab6f5b7"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ae0c9119-3ac4-4e6f-a073-ecc2f3679b80"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Dead"",
            ""id"": ""6b1d4733-999a-4114-b69e-30a62799e042"",
            ""actions"": [
                {
                    ""name"": ""DeathGamePlayAttack"",
                    ""type"": ""Button"",
                    ""id"": ""06138651-f12d-4064-9356-57339979164f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DeathMove"",
                    ""type"": ""Value"",
                    ""id"": ""4746df9c-6b7b-4046-8102-fdd6b4c9f5d4"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d4afdc7a-9b82-4c3b-a248-11a622fefe7a"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DeathGamePlayAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e36b7086-35b9-4608-9d42-482bfaa41edc"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DeathMove"",
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
        // Alive
        m_Alive = asset.FindActionMap("Alive", throwIfNotFound: true);
        m_Alive_Jump = m_Alive.FindAction("Jump", throwIfNotFound: true);
        m_Alive_Move = m_Alive.FindAction("Move", throwIfNotFound: true);
        m_Alive_Attack = m_Alive.FindAction("Attack", throwIfNotFound: true);
        m_Alive_Select = m_Alive.FindAction("Select", throwIfNotFound: true);
        // Dead
        m_Dead = asset.FindActionMap("Dead", throwIfNotFound: true);
        m_Dead_DeathGamePlayAttack = m_Dead.FindAction("DeathGamePlayAttack", throwIfNotFound: true);
        m_Dead_DeathMove = m_Dead.FindAction("DeathMove", throwIfNotFound: true);
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

    // Alive
    private readonly InputActionMap m_Alive;
    private IAliveActions m_AliveActionsCallbackInterface;
    private readonly InputAction m_Alive_Jump;
    private readonly InputAction m_Alive_Move;
    private readonly InputAction m_Alive_Attack;
    private readonly InputAction m_Alive_Select;
    public struct AliveActions
    {
        private @KTB_PlayerControls m_Wrapper;
        public AliveActions(@KTB_PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_Alive_Jump;
        public InputAction @Move => m_Wrapper.m_Alive_Move;
        public InputAction @Attack => m_Wrapper.m_Alive_Attack;
        public InputAction @Select => m_Wrapper.m_Alive_Select;
        public InputActionMap Get() { return m_Wrapper.m_Alive; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AliveActions set) { return set.Get(); }
        public void SetCallbacks(IAliveActions instance)
        {
            if (m_Wrapper.m_AliveActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_AliveActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_AliveActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_AliveActionsCallbackInterface.OnJump;
                @Move.started -= m_Wrapper.m_AliveActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_AliveActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_AliveActionsCallbackInterface.OnMove;
                @Attack.started -= m_Wrapper.m_AliveActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_AliveActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_AliveActionsCallbackInterface.OnAttack;
                @Select.started -= m_Wrapper.m_AliveActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_AliveActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_AliveActionsCallbackInterface.OnSelect;
            }
            m_Wrapper.m_AliveActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
            }
        }
    }
    public AliveActions @Alive => new AliveActions(this);

    // Dead
    private readonly InputActionMap m_Dead;
    private IDeadActions m_DeadActionsCallbackInterface;
    private readonly InputAction m_Dead_DeathGamePlayAttack;
    private readonly InputAction m_Dead_DeathMove;
    public struct DeadActions
    {
        private @KTB_PlayerControls m_Wrapper;
        public DeadActions(@KTB_PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @DeathGamePlayAttack => m_Wrapper.m_Dead_DeathGamePlayAttack;
        public InputAction @DeathMove => m_Wrapper.m_Dead_DeathMove;
        public InputActionMap Get() { return m_Wrapper.m_Dead; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DeadActions set) { return set.Get(); }
        public void SetCallbacks(IDeadActions instance)
        {
            if (m_Wrapper.m_DeadActionsCallbackInterface != null)
            {
                @DeathGamePlayAttack.started -= m_Wrapper.m_DeadActionsCallbackInterface.OnDeathGamePlayAttack;
                @DeathGamePlayAttack.performed -= m_Wrapper.m_DeadActionsCallbackInterface.OnDeathGamePlayAttack;
                @DeathGamePlayAttack.canceled -= m_Wrapper.m_DeadActionsCallbackInterface.OnDeathGamePlayAttack;
                @DeathMove.started -= m_Wrapper.m_DeadActionsCallbackInterface.OnDeathMove;
                @DeathMove.performed -= m_Wrapper.m_DeadActionsCallbackInterface.OnDeathMove;
                @DeathMove.canceled -= m_Wrapper.m_DeadActionsCallbackInterface.OnDeathMove;
            }
            m_Wrapper.m_DeadActionsCallbackInterface = instance;
            if (instance != null)
            {
                @DeathGamePlayAttack.started += instance.OnDeathGamePlayAttack;
                @DeathGamePlayAttack.performed += instance.OnDeathGamePlayAttack;
                @DeathGamePlayAttack.canceled += instance.OnDeathGamePlayAttack;
                @DeathMove.started += instance.OnDeathMove;
                @DeathMove.performed += instance.OnDeathMove;
                @DeathMove.canceled += instance.OnDeathMove;
            }
        }
    }
    public DeadActions @Dead => new DeadActions(this);
    private int m_XboxSchemeIndex = -1;
    public InputControlScheme XboxScheme
    {
        get
        {
            if (m_XboxSchemeIndex == -1) m_XboxSchemeIndex = asset.FindControlSchemeIndex("Xbox");
            return asset.controlSchemes[m_XboxSchemeIndex];
        }
    }
    public interface IAliveActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
    }
    public interface IDeadActions
    {
        void OnDeathGamePlayAttack(InputAction.CallbackContext context);
        void OnDeathMove(InputAction.CallbackContext context);
    }
}
