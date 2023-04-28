#Transpile model with bug
pcal wire_bug

# Check model with bug
tlc wire_bug 2>&1 | tee write_bug.log

#Transpile model with bug
pcal wire_fix

# Check model with bug
tlc wire_fix 2>&1 | tee write_fix.log


# https://www.c-sharpcorner.com/article/async-and-await-in-c-sharp/
