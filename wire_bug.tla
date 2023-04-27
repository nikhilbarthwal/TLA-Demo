------------------------------ MODULE wire_bug ------------------------------


EXTENDS Integers

(*--algorithm wire_bug
variables
    people = {"alice", "bob"},
    acc = [p \in people |-> 5],

define
    NoOverdrafts == \A p \in people: acc[p] >= 0
    \* EventuallyConsistent == <>[](acc["alice"] + acc["bob"] = 10)
end define;

process Wire \in 1..2
    variables
        sender = "alice",
        receiver = "bob",
        amount \in 1..acc[sender];

begin
    CheckFunds:
        if amount <= acc[sender] then
            Withdraw:
                acc[sender] := acc[sender] - amount;
            Deposit:
                acc[receiver] := acc[receiver] + amount;
        end if;
end process;

end algorithm; *)


=============================================================================
