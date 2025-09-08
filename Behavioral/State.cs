using Behavioral;
/*
    it alters its behavior based on the internal state change
*/
public interface IATMState
{
    void InsertCard();
    void RemoveCard();
    void EnterPin(int pin);
    void WithdrawAmount(int amount);
}
public class NoCardState : IATMState
{
    private ATM _atm;

    public NoCardState(ATM atm)
    {
        _atm = atm;
    }
    public void EnterPin(int pin)
    {
        Console.WriteLine("Insert Card First");
    }

    public void InsertCard()
    {
        Console.WriteLine("Card Inserted");
        _atm.currentState = _atm.HasCardState;
    }

    public void RemoveCard()
    {
        Console.WriteLine("No Cards To Remove");
    }

    public void WithdrawAmount(int amount)
    {
        Console.WriteLine("Insert Card First");
    }
}
public class HasCardState : IATMState
{
    private ATM _atm;

    public HasCardState(ATM atm)
    {
        _atm = atm;
    }
    public void EnterPin(int pin)
    {
        if (pin == 1234)
        {
            Console.WriteLine("Authenticted");
            _atm.currentState = _atm.AuthenticateState;
        }
        else
        {
            Console.WriteLine("Invalid Pin");
            RemoveCard();
        }

    }

    public void InsertCard()
    {
        Console.WriteLine("Card Already Inserted");
    }

    public void RemoveCard()
    {
        Console.WriteLine("Card Removed");
        _atm.currentState = _atm.NoCardState;
    }

    public void WithdrawAmount(int amount)
    {
        Console.WriteLine("Enter Pin To Withdraw Money");
    }
}
public class AuthenticateState : IATMState
{
    private ATM _atm;

    public AuthenticateState(ATM atm)
    {
        _atm = atm;
    }
    public void EnterPin(int pin)
    {
        Console.WriteLine("Pin Entered Already");
    }

    public void InsertCard()
    {
        Console.WriteLine("Card Already Inserted");
    }

    public void RemoveCard()
    {
        Console.WriteLine("Card Removed");
        _atm.currentState = _atm.NoCardState;
    }

    public void WithdrawAmount(int amount)
    {
        if (amount < _atm.inCashMachine)
        {
            Console.WriteLine($"Dispensing {amount}");
            _atm.inCashMachine -= amount;
            if (_atm.inCashMachine == 0)
            {
                Console.WriteLine("ATM is no out of money");
                _atm.currentState = _atm.OutOfMoneyState;
            }
        }
        else
        {
            Console.WriteLine("Not Enough cash In ATM");
            RemoveCard();
        }
    }
}
public class OutOfMoneyState : IATMState
{
    private ATM _atm;

    public OutOfMoneyState(ATM atm)
    {
        _atm = atm;
    }
    public void EnterPin(int pin)
    {
        Console.WriteLine("ATM Is Out Of Moeny");
    }

    public void InsertCard()
    {
        Console.WriteLine("ATM Is Out Of Money");
    }

    public void RemoveCard()
    {
        Console.WriteLine("No Cards Inserted To Remvoe");
    }

    public void WithdrawAmount(int amount)
    {
        Console.WriteLine("ATM is out of moeny");
    }
}

public class ATM : IATMState
{
    public IATMState NoCardState { get; }
    public IATMState HasCardState { get; }
    public IATMState AuthenticateState { get; }
    public IATMState OutOfMoneyState { get; }

    public IATMState currentState { get; set; }
    public int inCashMachine { get; set; }
    public ATM(int initialCash)
    {
        NoCardState = new NoCardState(this);
        HasCardState = new HasCardState(this);
        AuthenticateState = new AuthenticateState(this);
        OutOfMoneyState = new OutOfMoneyState(this);

        currentState = NoCardState;
        inCashMachine = initialCash;
    }
    public void InsertCard()
    {
        currentState.InsertCard();
    }

    public void RemoveCard()
    {
        currentState.RemoveCard();
    }

    public void EnterPin(int pin)
    {
        currentState.EnterPin(pin);
    }

    public void WithdrawAmount(int amount)
    {
        currentState.WithdrawAmount(amount);
    }
}