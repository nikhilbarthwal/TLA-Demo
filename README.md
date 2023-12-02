# Overview

This is a demo for showing modelling with TLA+. The example is adapted from [this](https://www.amazon.com/Practical-TLA-Planning-Driven-Development/dp/1484238281) book. The example use dotnet 8.0, so please make sure you have it [installed](https://dotnet.microsoft.com/en-us/download/dotnet/8.0).


# Algorithm

The algorithm for sending the model is shown below:

```
if amount <= acc[sender] then                   // Thread safe Check
    acc[sender] := acc[sender] - amount         // Thread safe Withdraw
    acc[receiver] := acc[receiver] + amount     // Thread safe Deposit
end if
```


# Installing the model checker

The example here uses [TLA CLI tool](https://github.com/pmer/tla-bin.git). To install it locally, run the installation script as shown below:

```
./install.sh
```


# Executing models

To execute the model which contains the bug, use the following commands (from the main directory):
```
cd Models
pcal wire_bug
tlc wire_bug
```

The first command will transcompile wire_bug.tla from plus-cal to tla+ code. The second command will execute the model.

Similarly, execute the model which contains the bug, use the following commands (from the main directory):

```
cd Models
pcal wire_fix
tlc wire_fix
```

Similar to the above example, the first command will transcompile wire_bug.tla from plus-cal to tla+ code. The second command will execute the model.


# Executing code

To execute the code with the bug, use the following commands (from the main directory):

```
cd TLA_Demo
dotnet run
```

And to execute the code with the fix, use the following command (from the main directory):

```
cd TLA_Demo
dotnet run -p:DefineConstants=FIXED
```
