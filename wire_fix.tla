------------------------------ MODULE wire_fix ------------------------------


EXTENDS Integers

(*--algorithm wire_fix
variables
    people = {"jack", "jill"},
    acc = [p \in people |-> 100],

define
    NoOverdrafts == \A p \in people: acc[p] >= 0
end define;

process Wire \in 1..2
    variables
        sender = "jack",
        receiver = "jill",
        amount \in 1..acc[sender];

begin
    CheckWithdraw:
        if amount <= acc[sender] then
            acc[sender] := acc[sender] - amount;
            Deposit:
                acc[receiver] := acc[receiver] + amount;
        end if;
end process;

end algorithm; *)

=============================================================================
