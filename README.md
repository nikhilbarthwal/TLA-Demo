

 ALGORITHM
-----------

if amount <= acc[sender] then                   // Thread safe Check
	acc[sender] := acc[sender] - amount         // Thread safe Withdraw
    acc[receiver] := acc[receiver] + amount     // Thread safe Deposit
end if


#Transpile model with bug
pcal wire_bug

# Check model with bug
tlc wire_bug 2>&1 | tee write_bug.log

#Transpile model with bug
pcal wire_fix

# Check model with bug
tlc wire_fix 2>&1 | tee write_fix.log

